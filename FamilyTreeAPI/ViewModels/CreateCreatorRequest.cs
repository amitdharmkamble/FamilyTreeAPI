namespace FamilyTreeAPI.ViewModels
{
    public class CreateCreatorRequest
    {
        public string FirstName { get; set; } = "John";
        public string LastName { get; set; } = "Doe";
        public DateTime DateOfBirth { get; set; }

    }
}
