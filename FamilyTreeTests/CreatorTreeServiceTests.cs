using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTreeAPI.Tests
{
    public class CreatorTreeServiceTests
    {
        [Fact]
        public void CreatorTreeServiceTests_CanCreatorCreateFamilyTree()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddDbContext<CreatorTreeContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .AddDbContext<CreatorContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .AddDbContext<FamilyTreeContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();
            Creator _creator;
            CreatorTree _creatorTree;
            FamilyTree _familyTree;
            using (var context = serviceProvider.GetService<CreatorContext>())
            {
                Assert.NotNull(context);
                _creator = new Creator
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First Name",
                    LastName = "Last Name",
                    CreatedAt = DateTime.UtcNow
                };
                context?.Add(_creator);
                context?.SaveChanges();
                var createdCreator = context?.Creators.FirstOrDefault(c => c.Id == _creator.Id);
                Assert.NotNull(createdCreator);
                Assert.Equal(_creator.Id, createdCreator?.Id);
            }
            using (var context = serviceProvider.GetService<CreatorTreeContext>())
            {
                Assert.NotNull(context);
                Guid _creatorTreeId = Guid.NewGuid();
                _creatorTree = new CreatorTree
                {
                    Id = _creatorTreeId,
                    CreatorId = _creator.Id,
                    FamilyTreeId = Guid.NewGuid(),
                    FamilyTreeName = "Test Creator Tree",
                    CreatedAt = DateTime.UtcNow,
                };
                _creatorTreeId = _creatorTree.Id;
                context.Add(_creatorTree);
                context.SaveChanges();
                var createdCreatorTree = context.CreatorTrees.FirstOrDefault(c => c.Id == _creatorTreeId);
                Assert.NotNull(createdCreatorTree);
                Assert.Equal(createdCreatorTree?.Id, _creatorTreeId);
                Assert.Equal(createdCreatorTree?.CreatorId, _creator.Id);
            }
            using (var context = serviceProvider.GetService<FamilyTreeContext>())
            {
                Assert.NotNull(context);
                Guid _familyTreeId = Guid.NewGuid();
                _familyTree = new FamilyTree
                {
                    Id = _familyTreeId,
                    Name = _creatorTree.FamilyTreeName,
                    CreatorTreeId = _creatorTree.Id,
                    CreatedAt = DateTime.UtcNow,
                    RootMemberId = _creator.Id
                };
                _familyTreeId = _familyTree.Id;
                context.Add(_familyTree);
                context.SaveChanges();
                var createdFamilyTree = context.FamilyTrees.FirstOrDefault(c => c.Id == _familyTreeId);
                Assert.NotNull(createdFamilyTree);
                Assert.Equal(createdFamilyTree?.Id, _familyTreeId);
                Assert.Equal(createdFamilyTree?.CreatorTreeId, _creatorTree.Id);
                Assert.Equal(createdFamilyTree?.Name, _creatorTree.FamilyTreeName);
            }
        }

    }
}
