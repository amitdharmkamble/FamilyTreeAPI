using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FamilyTreeAPI.Models
{
    public class FamilyTree : BaseAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int MemberCount { get; set; }

        [NotNull]
        public required Guid CreatorTreeId { get; set; }
        [NotNull]
        public required Guid RootMemberId { get; set; } = Guid.Empty;
    }
}
