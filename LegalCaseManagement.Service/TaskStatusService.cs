using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;

namespace LegalCaseManagement.Service
{
    public class TaskStatusService : GenService<MyTaskStatus>
    {
        public TaskStatusService(ApplicationDbContext context) : base(context)
        {

        }
    }
}