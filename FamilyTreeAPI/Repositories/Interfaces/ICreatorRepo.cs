namespace FamilyTreeAPI.Repositories.Interfaces
{
    public interface ICreatorRepo
    {
        Task<Guid> AddCreatorAsync(Models.Creator creator);
        Task<Models.Creator> GetCreatorByIdAsync(Guid id);
    }
}
