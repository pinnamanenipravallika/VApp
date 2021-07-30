namespace VApp.Models
{
    public class AffectedFamilyModel
    {
        public int EmpId { get; set; }
        public string MemberName { get; set; }
        public bool IsRecoveryed { get; set; }
        public int? RecoveryDuration { get; set; }
        public int? RelationshipId { get; set; }
    }
}
