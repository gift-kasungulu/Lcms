using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Domain
{
    public class Notice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? PdfFileName { get; set; } // Stores the file name of the uploaded PDF
        public byte[]? PdfFileContent { get; set; } // Stores the file content as a byte array
    }
}
