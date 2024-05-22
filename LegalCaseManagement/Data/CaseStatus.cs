using System.ComponentModel.DataAnnotations;

namespace LegalCaseManagement.Data
{
    public class CaseStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;

        // Navigation property
        public List<Case> Cases = new List<Case>();
    }
}
