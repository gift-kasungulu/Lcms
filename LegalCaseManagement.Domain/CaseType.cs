using System.ComponentModel.DataAnnotations;

namespace LegalCaseManagement.Data
{
    public class CaseType
    {
        [Key]
        public int CaseTypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;

        // Navigation property
       // public List<Case> Cases = new List<Case>();
    }
}
