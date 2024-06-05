using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalCaseManagement.Data
{
    public class Case
    {
        [Key]
        public int CaseId { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Petitioner is required.")]
        [StringLength(100, ErrorMessage = "Petitioner name cannot be longer than 100 characters.")]
        public string Petitioner { get; set; } = string.Empty;

        [Required(ErrorMessage = "Defendant is required.")]
        [StringLength(100, ErrorMessage = "Defendant name cannot be longer than 100 characters.")]
        public string Defendant { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string Discription { get; set; } = string.Empty;

        // Foreign key for CaseType
        [Required(ErrorMessage = "Case Type is required.")]
        public int CaseTypeId { get; set; }

        [ForeignKey("CaseTypeId")]
        public CaseType CaseType { get; set; } = new CaseType();

        // Foreign key for CaseStatus
        [Required(ErrorMessage = "Case Status is required.")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public CaseStatus CaseStatus { get; set; } = new CaseStatus();

        // Foreign key for ApplicationUser
        [Required(ErrorMessage = "Client is required.")]
        public string? UserId { get; set; }  // This is the foreign key property referencing ApplicationUser.Id

        [ForeignKey("UserId")]
        public ApplicationUser? AppUser { get; set; }  // Navigation property for the related ApplicationUser

         // Foreign key for Lawyer
        public int LawyerId { get; set; }
        public Lawyers? AssignedLawyer { get; set; } // Navigation property for Lawyer
    }
}
