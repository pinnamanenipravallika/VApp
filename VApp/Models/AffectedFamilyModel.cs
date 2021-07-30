using System.Collections.Generic;

namespace VApp.Models
{
    public class AffectedFamilyModel
    {
        public int EmpId { get; set; }
        public string MemberName { get; set; }
        public bool IsRecoveryed { get; set; }
        public int? RecoveryDuration { get; set; }
        public int? RelationshipId { get; set; }
        public List<RelationshipTypeModel> RelationshipTypes { get; set; } = new List<RelationshipTypeModel>();
    }
    public class RelationshipTypeModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
    }
}
