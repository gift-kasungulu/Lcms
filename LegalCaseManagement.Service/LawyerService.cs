using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;

namespace LegalCaseManagement.Data
{
    public class LawyerService : GenService<Lawyers>
    {
        private readonly ApplicationDbContext _context;
        public LawyerService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Lawyers> GetByIdAsync(string id)
        {
            return await _context.Lawyers.FindAsync(id);  // Assuming _context is your DbContext
        }
    }
}
