using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Domain
{
    public class MyCaseWonOrLost
    {
        [Key]
        public int WonLostId { get; set; }
        public string Name { get; set; } = String.Empty;


    }
}
