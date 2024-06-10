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
    }
}
