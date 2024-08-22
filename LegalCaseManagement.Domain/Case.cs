using LegalCaseManagement.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace LegalCaseManagement.Data
{
    public class Case
    {
        [Key]
        public int CaseId { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Next Hearing Date is required.")]
        public DateTime? EndDate { get; set; }
        public string? Remark { get; set; } // added this to hold the remark of the next date when or if changed 

        [Required(ErrorMessage = "Registration Date is required.")]
        public DateTime? RegistrationDate { get; set; }

        [Required(ErrorMessage = "Registration Number is required.")]
        public string? RegistrationNo { get; set; }

        [Required(ErrorMessage = "Petitioner is required.")]
        [StringLength(100, ErrorMessage = "Petitioner name cannot be longer than 100 characters.")]
        public string Petitioner { get; set; } = string.Empty;

        [Required(ErrorMessage = "Court Name is required.")]
        [StringLength(100, ErrorMessage = "Court name cannot be longer than 100 characters.")]
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

        [ForeignKey("WonLostId")]
        public int WonLostId { get; set; }
        public MyCaseWonOrLost WonOrLost { get; set; } = new MyCaseWonOrLost();

        // Foreign key for ApplicationUser
        [Required(ErrorMessage = "Client is required.")]
        public string? UserId { get; set; }  // This is the foreign key property referencing ApplicationUser.Id

        [ForeignKey("UserId")]
        public ApplicationUser? AppUser { get; set; }  // Navigation property for the related ApplicationUser

        // Optional file attachment
        public string? FileAttachment { get; set; }
                                                    
        public string? CreatedByUserId { get; set; } 
        public DateTime CreatedAt { get; set; } 

        [ForeignKey("CreatedByUserId")]
        public ApplicationUser? CreatedByUser { get; set; } 
        public ICollection<CaseDocument> CaseDocuments { get; set; }
        public string? AssignedLawyerId { get; set; }
        [ForeignKey("AssignedLawyerId")]
        public Lawyers? AssignedLawyer { get; set; }
        public ICollection<MyTask> Tasks { get; set; } = new List<MyTask>();

    }
}
