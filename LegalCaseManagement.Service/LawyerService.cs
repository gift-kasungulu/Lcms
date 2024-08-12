using LegalCaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using LegalCaseManagement.Domain;
using LegalCaseManagement.Service;

namespace LegalCaseManagement.Data
{
    public class LawyerService : GenService<Lawyers>, ILawyerService
    {
        private readonly ApplicationDbContext _context;
        public LawyerService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<List<Lawyers>> GetAllAsync()
        {
            return await _context.Lawyers.ToListAsync();
        }


        public async Task<Lawyers> GetByIdAsync(string id)
        {
            return await _context.Lawyers.FindAsync(id);  // Assuming _context is your DbContext
        }

        public async Task<bool> DeleteAsync(Lawyers lawyer)
        {
            try
            {
                // Find related tasks asynchronously
                var tasks = await _context.MyTasks.Where(t => t.LawyerId == lawyer.Id).ToListAsync();

                // Remove related tasks
                _context.MyTasks.RemoveRange(tasks);

                // Remove the lawyer
                _context.Lawyers.Remove(lawyer);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException dbEx)
            {
                // Log the database update exception (use a logger in a real application)
                Console.WriteLine($"Database update error: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log the general exception (use a logger in a real application)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> UpdateLawyerAsync(Lawyers lawyer)
        {
            try
            {
                _context.Lawyers.Attach(lawyer);
                _context.Entry(lawyer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating lawyer: {ex.Message}");
                return false;
            }
        }

    }
}

