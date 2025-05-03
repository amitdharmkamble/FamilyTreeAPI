using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using FamilyTreeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Repositories
{
    public class CreatorRepo : ICreatorRepo
    {
        private readonly CreatorContext _context;
        public CreatorRepo(CreatorContext context)
        {
            _context = context;
        }
        public async Task<List<Creator>> GetAllCreatorsAsync()
        {
            return await _context.Creators.ToListAsync();
        }
        public async Task<Creator?> GetCreatorByIdAsync(Guid id)
        {
            return await _context.Creators.FindAsync(id);
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
