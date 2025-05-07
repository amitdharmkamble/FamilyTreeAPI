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

        public async Task<CreatorResponse> GetCreatorByIdAsync(Guid id)
        {
            var creatorEntity = await _cretorRepo.GetCreatorByIdAsync(id);
            if (creatorEntity.Id != Guid.Empty)
            {
                var creatorResponse = new CreatorResponse
                {
                    Id = creatorEntity.Id,
                    FirstName = creatorEntity.FirstName,
                    LastName = creatorEntity.LastName,
                    DateOfBirth = creatorEntity.DateOfBirth
                };
                return creatorResponse;
            }
            else
            {
                return new CreatorResponse();
            }
        }
    }
}
