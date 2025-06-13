using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FamilyTreeAPI.ViewModels
{
    public class FamilyTreeResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid CreatorTreeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? RootNodeId { get; set; }
        public string? Description { get; set; }
    }
}
