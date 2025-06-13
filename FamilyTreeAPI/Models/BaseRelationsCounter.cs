namespace FamilyTreeAPI.Models
{
    public class BaseRelationsCounter
    {
        public required Guid MemberId { get; set; }
        public required BaseRelationEnum BaseRelationEnum { get; set; }
        public required int Count { get; set; }
    }
}
