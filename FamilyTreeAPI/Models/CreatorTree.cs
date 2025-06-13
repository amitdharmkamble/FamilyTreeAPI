using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FamilyTreeAPI.Models
{
    public class CreatorTree
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CreatorId { get; set; }
        [NotNull]
        public required string FamilyTreeName { get; set; }
        [NotNull]
        public Guid FamilyTreeId{ get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
