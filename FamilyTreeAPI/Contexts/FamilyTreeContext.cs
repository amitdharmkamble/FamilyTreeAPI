using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class FamilyTreeContext : BaseAuditableContext
    {
        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options) : base(options)
        {
        }
        public DbSet<FamilyTree> FamilyTrees { get; set; } = null!;
    }
}
