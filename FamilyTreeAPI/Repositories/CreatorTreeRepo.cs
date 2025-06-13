using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using FamilyTreeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FamilyTreeAPI.Repositories
{
    public class CreatorTreeRepo : ICreatorTreeRepo
    {
        private readonly CreatorContext _creatorContext;
        private readonly CreatorTreeContext _creatorTreeContext;
        private readonly FamilyTreeContext _familyTreeContext;

        public CreatorTreeRepo(CreatorContext creatorContext, CreatorTreeContext creatorTreeContext, FamilyTreeContext familyTreeContext)
        {
            _creatorContext = creatorContext;
            _creatorTreeContext = creatorTreeContext;
            _familyTreeContext = familyTreeContext;
        }

        public async Task<FamilyTree> CreateFamilyTree(Guid creatorId, string familyTreeName, string Description)
        {
            if (creatorId == Guid.Empty)
                throw new ArgumentException("Invalid Creator Id");

            Creator creator = await GetCreatorByIdAsync(creatorId);
            if (creator == null)
                throw new Exception("Creator not found");

            CreatorTree creatorTree = await CreateCreatorTreeAsync(creator, creatorId, familyTreeName);
            FamilyTree familyTree = await CreateFamilyTreeRecordAsync(creatorTree, Description);

            return familyTree ?? throw new Exception("Error while creating family tree");
        }

        private async Task<Creator> GetCreatorByIdAsync(Guid creatorId)
        {
            return await _creatorContext.Creators.FirstOrDefaultAsync(c => c.Id == creatorId) ?? new Creator();
        }

        private async Task<CreatorTree> CreateCreatorTreeAsync(Creator creator, Guid creatorId, string requestedName)
        {
            var creatorTreeId = Guid.NewGuid();
            var familyTreeName = string.IsNullOrEmpty(requestedName)
                ? $"{creator.FirstName}'s Family Tree"
                : requestedName;

            var creatorTree = new CreatorTree
            {
                Id = creatorTreeId,
                CreatorId = creatorId,
                FamilyTreeName = familyTreeName,
                CreatedAt = DateTime.UtcNow,
                FamilyTreeId = Guid.NewGuid()
            };

            _creatorTreeContext.Add(creatorTree);
            await _creatorTreeContext.SaveChangesAsync();

            var savedCreatorTree = await _creatorTreeContext.CreatorTrees.FirstOrDefaultAsync(ct => ct.Id == creatorTreeId);

            return savedCreatorTree ?? throw new Exception("Error while creating creator tree");
        }

        private async Task<FamilyTree> CreateFamilyTreeRecordAsync(CreatorTree creatorTree, string description)
        {
            var familyTreeId = Guid.NewGuid();
            try
            {
                var familyTree = new FamilyTree
                {
                    Id = familyTreeId,
                    Name = creatorTree.FamilyTreeName,
                    Description = description,
                    RowVersion = new byte[] { Byte.MinValue },
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow,
                    CreatorTreeId = creatorTree.Id,
                    RootMemberId = creatorTree.Id,
                };

                _familyTreeContext.Add(familyTree);
                await _familyTreeContext.SaveChangesAsync();
                var savedFamilyTree = await _familyTreeContext.familyTrees.FirstOrDefaultAsync(f => f.Id == familyTreeId);
                if(savedFamilyTree != null)
                {
                    return savedFamilyTree;
                }
                else
                {
                    throw new Exception("Error while creating Family Tree");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error while creating Family Tree", e);
            }
        }

    }
}
