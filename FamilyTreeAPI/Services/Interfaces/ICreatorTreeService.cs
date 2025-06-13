using FamilyTreeAPI.ViewModels;

namespace FamilyTreeAPI.Services.Interfaces
{
    public interface ICreatorTreeService
    {
        public Task<FamilyTreeResponse> CreateFamilyTree(Guid CreatorId, string FamilyTreeName, string Description);
    }
}
