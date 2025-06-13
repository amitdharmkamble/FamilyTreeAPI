using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTreeAPI.Tests
{
    public class CreatorTreeContextTests
    {
        [Fact]
        public void CreatorTreeContext_CanBeInstantiatedWithInMemoryDatabase()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CreatorTreeContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();
            var context = serviceProvider.GetService<CreatorTreeContext>();
            Assert.NotNull(context);
        }

        [Fact]
        public void CreatorTreeContext_CanAddAndRetrieveCreatorTree()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CreatorTreeContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();
            using (var context = serviceProvider.GetService<CreatorTreeContext>())
            {
                Assert.NotNull(context);
                Guid _creatorTreeId = Guid.Empty;
                if (context != null)
                {
                    FamilyTreeAPI.Models.CreatorTree creatorTree = new FamilyTreeAPI.Models.CreatorTree
                    {
                        Id = Guid.NewGuid(),
                        CreatorId = Guid.NewGuid(),
                        FamilyTreeId = Guid.NewGuid(),
                        FamilyTreeName = "Test Creator Tree",
                        CreatedAt = DateTime.UtcNow,
                    };
                    _creatorTreeId = creatorTree.Id;
                    context.Add(creatorTree);
                    context.SaveChanges();
                    var createdCreator = context.CreatorTrees.FirstOrDefault(c => c.Id == _creatorTreeId);
                    Assert.Equal(_creatorTreeId, createdCreator?.Id);
                }
            }
        }
    }
}
