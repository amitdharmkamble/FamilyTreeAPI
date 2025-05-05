using FamilyTreeAPI.Models;
using FamilyTreeAPI.Repositories.Interfaces;
using FamilyTreeAPI.Services.Interfaces;
using FamilyTreeAPI.ViewModels;

namespace FamilyTreeAPI.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly ICreatorRepo _cretorRepo;

        public CreatorService(ICreatorRepo _cretorRepo) 
        {
            this._cretorRepo = _cretorRepo;
        }

        public async Task<Guid> AddCreatorAsync(CreateCreatorRequest createCreatorRequest)
        {
            try
            {
                Guid createdCreatorId = await _cretorRepo.AddCreatorAsync(new Creator
                {
                    Id = Guid.NewGuid(),
                    FirstName = createCreatorRequest.FirstName,
                    LastName = createCreatorRequest.LastName,
                    DateOfBirth = createCreatorRequest.DateOfBirth,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                return createdCreatorId;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }

        }
    }
}
