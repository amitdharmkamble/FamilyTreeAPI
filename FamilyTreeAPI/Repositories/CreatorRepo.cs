﻿using System.Linq;
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
        public Task<Guid> AddCreatorAsync(Creator creator)
        {
            try
            {
                using (var transactionScope = _context.Database.BeginTransaction())
                {
                    _context.Creators.Add(creator);
                    _context.SaveChanges();
                    transactionScope.Commit();
                    _creatorId = creator.Id;
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error occurred while creating creator. \n: {ex.Message}");
            }

            return Task.FromResult(_creatorId);
        }

        public async Task<Creator> GetCreatorByIdAsync(Guid id)
        {
            return await _context.Creators
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id) 
                ?? new Creator()
                {
                    Id = Guid.Empty
                };
        }
    }
}
