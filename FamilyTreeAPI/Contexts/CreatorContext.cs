using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class CreatorContext : DbContext
    {
        public CreatorContext(DbContextOptions<CreatorContext> options) : base(options) { }

        public DbSet<Creator> Creators { get; set; } = null!;
    }
}
