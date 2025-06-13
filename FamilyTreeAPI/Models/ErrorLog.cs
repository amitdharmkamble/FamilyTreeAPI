namespace FamilyTreeAPI.Models
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public required string Message { get; set; }
        public required string StackTrace { get; set; }
        public required string Path { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
