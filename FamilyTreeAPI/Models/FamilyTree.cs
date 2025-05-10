using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FamilyTreeAPI.Models
{
    public class FamilyTree
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        [NotNull]
        public Guid CreatorTreeId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? RootNodeId { get; set; }
        public string? Description { get; set; }
    }
}
