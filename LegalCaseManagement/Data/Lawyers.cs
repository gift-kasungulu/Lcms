using System.ComponentModel.DataAnnotations;

namespace LegalCaseManagement.Data
{
    public class Lawyers
    {
        [Key]
        public int LawyerId { get; set; }
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
    }
}
