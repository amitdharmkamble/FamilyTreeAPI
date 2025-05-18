namespace FamilyTreeAPI.Models
{
    public class BaseRelationNavigator
    {
        public required Guid SourceMemberId { get; set; }
        public required BaseRelationEnum BaseRelationEnum { get; set; }
        public required List<Guid> DestinationMemberIds { get; set; }
    }
}