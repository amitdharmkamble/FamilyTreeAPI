using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class FamilyMemberContext : DbContext
    {
        public FamilyMemberContext(DbContextOptions<FamilyMemberContext> options) : base(options)
        {
        }
        public DbSet<FamilyMember> FamilyMembers { get; set; } = null!;
    }
}
