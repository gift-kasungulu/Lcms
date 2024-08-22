using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service.LegalServices
{
    public class MywonLostCasServicee : GenService<MyCaseWonOrLost>
    {
        public MywonLostCasServicee(ApplicationDbContext context) : base(context)
        {
                
        }
    }
}
