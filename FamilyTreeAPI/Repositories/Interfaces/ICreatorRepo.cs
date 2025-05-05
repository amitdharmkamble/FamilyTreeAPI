namespace FamilyTreeAPI.Repositories.Interfaces
{
    public interface ICreatorRepo
    {
        Task AddCreatorAsync(Models.Creator creator);
    }
}
