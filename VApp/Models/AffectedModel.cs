using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VApp.Models
{
    public class AffectedModel
    {
        public int EmpId { get; set; }
        public bool IsRecoveryed { get; set; }
        [Required]
        public int? RecoveryDuration { get; set; }
        public bool IsFamilyAffected { get; set; }
        public List<AffectedFamilyModel> AffectedFamilyModels { get; set; }
        public List<RelationshipTypeModel> RelationshipTypes { get; set; } = new List<RelationshipTypeModel>();
    }
}
