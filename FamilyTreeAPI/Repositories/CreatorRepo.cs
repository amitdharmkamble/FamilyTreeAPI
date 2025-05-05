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
        private static Guid _creatorId;
        private readonly CreatorContext _context;
        public CreatorRepo(CreatorContext context)
        {
            _context = context;
        }
        public Task AddCreatorAsync(Creator creator)
        {
            try
            {
                using (var transactionScope = _context.Database.BeginTransaction())
                {
                    _context.Creators.Add(creator);
                    _context.SaveChanges();
                    transactionScope.Commit();
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error occurred while creating creator. \n: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
