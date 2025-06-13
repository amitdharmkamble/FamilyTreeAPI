using FamilyTreeAPI.Repositories.Interfaces;
using FamilyTreeAPI.Services.Interfaces;
using FamilyTreeAPI.ViewModels;

namespace FamilyTreeAPI.Services
{
    public class FamilyTreeService : ICreatorTreeService
    {
        private readonly ICreatorTreeRepo _creatorTreeRepo;
        public FamilyTreeService(ICreatorTreeRepo creatorTreeRepo)
        {
            _creatorTreeRepo = creatorTreeRepo;
        }
        public async Task<FamilyTreeResponse> CreateFamilyTree(Guid CreatorId, string FamilyTreeName, string Description)
        {
            var familyTree = await _creatorTreeRepo.CreateFamilyTree(CreatorId, FamilyTreeName, Description);
            return new FamilyTreeResponse
            {
                Name = familyTree.Name,
                CreatedAt = familyTree.CreatedAt,
                CreatorTreeId = familyTree.CreatorTreeId,
                Description = familyTree.Description,
                Id = familyTree.Id,
                RootNodeId = CreatorId,
            };
        }
    }
}
