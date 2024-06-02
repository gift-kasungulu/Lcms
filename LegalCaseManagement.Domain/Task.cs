using LegalCaseManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Domain
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Deadline { get; set; }
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;  // This is the foreign key property referencing ApplicationUser.Id

        [ForeignKey("UserId")]
        public ApplicationUser? AppUser { get; set; } // navigation to user to be specific Team Member, Task is assigned to this user

 
        public int CaseId { get; set; }
        public Case? mycase { get; set; } // Navigation to Case

    }
}
