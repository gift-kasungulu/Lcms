using LegalCaseManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LegalCaseManagement.Domain
{
    public class Priority
{
    [Key]
    public int PriorityId { get; set; }
    public string Name { get; set; }
    
}
}
