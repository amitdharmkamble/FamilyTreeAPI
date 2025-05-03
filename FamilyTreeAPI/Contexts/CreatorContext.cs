using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class CreatorContext : DbContext
    {
        public CreatorContext() { }
        public CreatorContext(DbContextOptions<CreatorContext> options) : base(options) { }

        public DbSet<Models.Creator> Creators { get; set; } = null!;
    }
}
