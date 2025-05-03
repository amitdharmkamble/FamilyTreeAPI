using FamilyTreeAPI.Models;
using FamilyTreeAPI.Repositories.Interfaces;
using FamilyTreeAPI.Services.Interfaces;

namespace FamilyTreeAPI.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly ICreatorRepo _cretorRepo;
        public CreatorService(ICreatorRepo _cretorRepo) 
        {
            this._cretorRepo = _cretorRepo;
        }

        public Task AddCreatorAsync(Creator creator)
        {
            return _cretorRepo.AddCreatorAsync(creator);
        }

        public Task DeleteCreatorAsync(Guid id)
        {
            return _cretorRepo.DeleteCreatorAsync(id);
        }

        public Task<List<Creator>> GetAllCreatorsAsync()
        {
            return _cretorRepo.GetAllCreatorsAsync();
        }

        public Task<Creator?> GetCreatorByIdAsync(Guid id)
        {
            return _cretorRepo.GetCreatorByIdAsync(id);
        }

        public Task UpdateCreatorAsync(Creator creator)
        {
            return _cretorRepo.UpdateCreatorAsync(creator);
        }
    }
}
