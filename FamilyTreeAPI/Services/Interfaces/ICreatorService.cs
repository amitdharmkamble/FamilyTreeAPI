namespace FamilyTreeAPI.Services.Interfaces
{
    public interface ICreatorService
    {
        Task<List<Models.Creator>> GetAllCreatorsAsync();
        Task<Models.Creator?> GetCreatorByIdAsync(Guid id);
        Task AddCreatorAsync(Models.Creator creator);
        Task UpdateCreatorAsync(Models.Creator creator);
        Task DeleteCreatorAsync(Guid id);
    }
}
