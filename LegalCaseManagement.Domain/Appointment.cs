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

        [Required]
        public string? ClientName { get; set; }

        [Required]
        public string? MobileNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public string? Note { get; set; }

        [Required]
        public string? Email { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
