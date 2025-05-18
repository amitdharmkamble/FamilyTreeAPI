namespace FamilyTreeAPI.Models
{
    public class BaseAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public required byte[] RowVersion { get; set; }
    }
}
