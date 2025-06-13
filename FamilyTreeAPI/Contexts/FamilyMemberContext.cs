using FamilyTreeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeAPI.Contexts
{
    public class FamilyMemberContext : BaseAuditableContext
    {
        public FamilyMemberContext(DbContextOptions<FamilyMemberContext> options) : base(options)
        {
        }
        public DbSet<FamilyMember> FamilyMembers { get; set; } = null!;
    }
}
