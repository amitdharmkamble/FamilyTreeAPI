using System.Linq;
using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using FamilyTreeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace FamilyTreeAPI.Repositories
{
    public class CreatorRepo : ICreatorRepo
    {
        private readonly Guid _creatorId;
        private readonly CreatorContext _context;
        private readonly Creator[] _creators = new Creator[100];
        public CreatorRepo(CreatorContext context)
        {
            _context = context;
        }
        public Task<List<Creator>> GetAllCreatorsAsync()
        {
            var creators = _creators.ToList();
            return Task.FromResult(creators);
        }
        public Task<Creator?> GetCreatorByIdAsync(Guid id)
        {
            var creator = _creators.FirstOrDefault(c => c.Id == id);
            if (creator == null && _creatorId != Guid.Empty)
            {
                creator =  _creators.FirstOrDefault(c => c.Id == _creatorId);
            }
            return Task.FromResult(creator);
        }
        public async Task AddCreatorAsync(Creator creator)
        {
            await _context.Creators.AddAsync(creator);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCreatorAsync(Creator creator)
        {
            _context.Creators.Update(creator);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCreatorAsync(Guid id)
        {
            var creator = await GetCreatorByIdAsync(id);
            if (creator != null)
            {
                _context.Creators.Remove(creator);
                await _context.SaveChangesAsync();
            }
        }
    }
}
