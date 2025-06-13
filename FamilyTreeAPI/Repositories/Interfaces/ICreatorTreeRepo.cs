using FamilyTreeAPI.Models;

namespace FamilyTreeAPI.Repositories.Interfaces
{
    public interface ICreatorTreeRepo
    {
        public Task<FamilyTree> CreateFamilyTree(Guid CreatorId, string FamilyTreeName, string Description);
    }
}
