
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalCaseManagement.Data
{
    public class Case
    {
        [Key]
        public int CaseId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Petitioner { get; set; } = string.Empty;
        public string Defendant { get; set; } = string.Empty;

        // Foreign key for CaseType
        public int CaseTypeId { get; set; }
        [ForeignKey("CaseTypeId")]
        public CaseType CaseType { get; set; } = new CaseType();

        // Foreign key for CaseStatus
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public CaseStatus CaseStatus { get; set; } = new CaseStatus();

        // Foreign key for ApplicationUser
        public string UserId { get; set; }  // This is the foreign key property referencing ApplicationUser.Id
        [ForeignKey("UserId")]
        public ApplicationUser AppUser { get; set; }  // Navigation property for the related ApplicationUser

        
    }
}
