using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;

namespace LegalCaseManagement.Service
{
    public class PriorityService : GenService<Priority>
    {
        public PriorityService(ApplicationDbContext context) : base(context)
        {

        }
    }
}