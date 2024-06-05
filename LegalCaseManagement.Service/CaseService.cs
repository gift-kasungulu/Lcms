using LegalCaseManagement.Service;
using LegalCaseManagement.Domain;
using LegalCaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalCaseManagement.Data
{
    public class CaseService : GenService<Case>, ICaseService
    {
        private readonly ApplicationDbContext _context;

        public CaseService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Case>> GetCasesByLawyerIdAsync(int lawyerId)
        {
            return await _context.Cases
                .Where(c => c.LawyerId == lawyerId)
                .Include(c => c.AppUser)
                .Include(c => c.CaseStatus)
                .Include(c => c.CaseType)
                .ToListAsync();
        }
    }
}
