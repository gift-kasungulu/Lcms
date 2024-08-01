using LegalCaseManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Domain
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string? ClientName { get; set; }
        
        public string? MobileNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public string? Note { get; set; }
        public string? Email { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string? CreatedBy { get; set; } //this will help me store the ID of the user that created the Appointment for easy tracking 
        public bool IsApproved { get; set; } //help to track the approved cases 
    }
}
