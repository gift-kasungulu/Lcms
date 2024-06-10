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


        [Required]
        public string LawyerId { get; set; } // Foreign key for Lawyers, referencing the Id property from IdentityUser
        [ForeignKey("LawyerId")]
        public virtual Lawyers LawyerInfo { get; set; } // Navigation property for Lawyers

        public int CaseId { get; set; }

        [ForeignKey("CaseId")]
        public Case? Case { get; set; }


    }
}
