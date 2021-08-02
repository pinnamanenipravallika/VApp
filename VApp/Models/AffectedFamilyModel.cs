using System.ComponentModel.DataAnnotations;

namespace VApp.Models
{
    public class AffectedFamilyModel
    {
        public int EmpId { get; set; }

        [Required]
        public string MemberName { get; set; }
        public bool IsRecoveryed { get; set; }
        public int? RecoveryDuration { get; set; }

        [Required]
        public int? RelationshipId { get; set; }
    }
}
