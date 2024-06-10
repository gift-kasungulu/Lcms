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
       
        public string LFirstName { get; set; } = string.Empty;
        public string LLastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double CaseWinPercentage { get; set; }
        public string CaseType { get; set; } = string.Empty;
        public int ExperienceYears { get; set; } 
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; } // Adding the Gender field using enum

        public List<Task> TodoTask { get; set; }


    }
}
