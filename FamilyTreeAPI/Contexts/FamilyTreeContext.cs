using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options) : base(options)
        {
        }
        public DbSet<FamilyTree> familyTrees { get; set; } = null!;
    }
}
