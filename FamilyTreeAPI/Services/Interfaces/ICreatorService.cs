using FamilyTreeAPI.ViewModels;

namespace FamilyTreeAPI.Services.Interfaces
{
    public interface ICreatorService
    {
        Task<Guid> AddCreatorAsync(CreateCreatorRequest createCreatorRequest);
    }
}
