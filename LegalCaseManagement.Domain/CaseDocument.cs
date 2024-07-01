using LegalCaseManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Domain
{
    public class CaseDocument
    {
        [Key]
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public Case Case { get; set; }
    }
}
