using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegalCaseManagement.Data
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Lawyers : ApplicationUser
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; } = string.Empty;
        public double CaseWinPercentage { get; set; }
        public string CaseType { get; set; } = string.Empty;
        public int ExperienceYears { get; set; } 
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; } // Adding the Gender field using enum

        public List<Task> TodoTask { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IBrowserFile? ImageFile { get; set; }
        public ICollection<Case> AssignedCases { get; set; } = new List<Case>(); // The list of cases that are assigned to the lawyer



    }
}
