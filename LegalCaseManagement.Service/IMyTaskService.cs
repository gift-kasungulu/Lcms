using LegalCaseManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface IMyTaskService
    {
        Task<List<MyTask>> GetTasksByLawyerIdAsync(string  lawyerId);
        Task<MyTask> GetByIdAsync(int taskId);
        Task<bool> UpdateAsync(MyTask task);
        Task<bool> AddAsync(MyTask newTask);
        Task<List<MyTask>> GetTasksDueInOneDayAsync();
    }
}
