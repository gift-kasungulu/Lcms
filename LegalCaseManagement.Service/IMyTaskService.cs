using LegalCaseManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface IMyTaskService
    {
        Task<List<MyTask>> GetTasksByLawyerIdAsync(int lawyerId);
    }
}
