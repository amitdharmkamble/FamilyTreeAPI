namespace FamilyTreeAPI.ViewModels
{
    public class CreatorResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CreatorResponse(Guid id, string firstName, string lastName, DateTime dateOfBirth, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public CreatorResponse()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = null;
            CreatedAt = DateTime.MinValue;
            UpdatedAt = DateTime.MinValue;
        }
    }
}
