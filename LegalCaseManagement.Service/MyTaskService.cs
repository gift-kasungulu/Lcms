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
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MyTaskService(ApplicationDbContext context, IServiceScopeFactory serviceScopeFactory) : base(context)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        // Implement the interface method
        public async Task<List<MyTask>> GetTasksByLawyerIdAsync(int lawyerId)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                return await context.MyTasks
                    .Where(t => t.LawyerId == lawyerId)
                    .Include(t => t.Priority)
                    .Include(t => t.Status)
                    .Include(t => t.AssignedLawyer)
                    .Include(t => t.Case)
                    .ToListAsync();
            }
        }
    }
}
