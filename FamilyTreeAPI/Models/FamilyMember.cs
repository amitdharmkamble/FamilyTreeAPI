using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class FamilyMember : BaseAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public required string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public required bool IsMale { get; set; }
        public required bool IsFemale { get; set; }
        public string? Notes { get; set; }

        public required Guid TreeId { get; set; }
        public required List<BaseRelationsCounter> RelationCounters { get; set; }
        public required List<BaseRelationNavigator> RelationNavigators { get; set; }
    }
}
