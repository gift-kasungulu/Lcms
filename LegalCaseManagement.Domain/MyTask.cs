using LegalCaseManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LegalCaseManagement.Domain
{
    public class MyTask
    {
        [Key]
        public int TaskId { get; set; }

        public string? Description { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int PriorityId { get; set; } // Foreign key for Priority

        [ForeignKey("PriorityId")]
        public Priority? Priority { get; set; } // Navigation property for Priority

        public int StatusId { get; set; } // Foreign key for TaskStatus

        [ForeignKey("StatusId")]
        public MyTaskStatus? Status { get; set; } // Navigation property for TaskStatus

        public int LawyerId { get; set; } // Foreign key for Lawyer

        [ForeignKey("LawyerId")]
        public Lawyers? AssignedLawyer { get; set; } // Navigation property for Lawyer

        // Foreign key for ApplicationUser
        //[Required(ErrorMessage = "Client is required.")]
        //public string? UserId { get; set; }  // This is the foreign key property referencing ApplicationUser.Id

        //[ForeignKey("UserId")]
        //public ApplicationUser? AppUser { get; set; }  // Navigation property for the related ApplicationUser

        public int CaseId { get; set; }

        [ForeignKey("CaseId")]
        public Case? Case { get; set; }


    }
}
