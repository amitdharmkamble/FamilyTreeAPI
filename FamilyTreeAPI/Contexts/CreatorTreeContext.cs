using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class CreatorTreeContext : DbContext
    {
        public CreatorTreeContext(DbContextOptions<CreatorTreeContext> options) : base(options)
        {

        }
        public DbSet<CreatorTree> CreatorTrees { get; set; } 
    }
}
