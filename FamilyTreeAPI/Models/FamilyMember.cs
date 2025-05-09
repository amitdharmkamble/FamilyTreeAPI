using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class FamilyMember
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TreeId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Guid? ParentId { get; set; }
        public Guid? SpouseId { get; set; }
        public List<Guid> Children { get; set; } = new List<Guid>();
        public string? Notes { get; set; }
    }
}
