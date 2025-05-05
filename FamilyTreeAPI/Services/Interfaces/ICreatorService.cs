using FamilyTreeAPI.ViewModels;

namespace FamilyTreeAPI.Services.Interfaces
{
    public interface ICreatorService
    {
        Task<bool> AddCreatorAsync(CreateCreatorRequest createCreatorRequest);
    }
}
