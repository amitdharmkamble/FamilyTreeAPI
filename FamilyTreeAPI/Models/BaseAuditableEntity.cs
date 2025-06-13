using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class BaseAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
