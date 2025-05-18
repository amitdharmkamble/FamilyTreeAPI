namespace FamilyTreeAPI.ViewModels
{
    public class CreateFamilyTreeRequest
    {
        public Guid CreatorId { get; set; }
        public string? FamilyTreeName { get; set; }
        public string? FamilyTreeDescription { get; set; }
    }
}
