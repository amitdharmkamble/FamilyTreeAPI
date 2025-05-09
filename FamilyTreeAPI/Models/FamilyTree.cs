using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class FamilyTree
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid CreatorId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? RootNodeId { get; set; }
        public string? Description { get; set; }
    }
}
