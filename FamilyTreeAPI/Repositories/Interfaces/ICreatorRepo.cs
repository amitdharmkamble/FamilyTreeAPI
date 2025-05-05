namespace FamilyTreeAPI.Repositories.Interfaces
{
    public interface ICreatorRepo
    {
        Task<Guid> AddCreatorAsync(Models.Creator creator);
    }
}
