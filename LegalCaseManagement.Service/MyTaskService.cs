using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public class MyTaskService : GenService<MyTask>, IMyTaskService
    {
        private readonly ApplicationDbContext _context;

        public MyTaskService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Implement the interface method
        public async Task<List<MyTask>> GetTasksByLawyerIdAsync(string lawyerId)
        {
            return await _context.MyTasks
                .Where(t => t.LawyerId == lawyerId)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.Case)
                .ToListAsync();
        }

        public async Task<MyTask> GetByIdAsync(int taskId)
    {
        return await _context.MyTasks
            .Include(t => t.Priority)
            .Include(t => t.Status)
            .Include(t => t.LawyerInfo)
            .Include(t => t.Case)
            .FirstOrDefaultAsync(t => t.TaskId == taskId);
    }

      public async Task<bool> UpdateAsync(MyTask task)
    {
        _context.MyTasks.Update(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddAsync(MyTask newTask)
    {
        await _context.MyTasks.AddAsync(newTask);
        await _context.SaveChangesAsync();
        return true;
    }
    }
}
