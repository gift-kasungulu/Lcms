using System;
using System.Linq;
using System.Text;
using LegalCaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegalCaseManagement.Domain;

namespace LegalCaseManagement.Service
{
    public class WonOrLostCaseService
    {
        private readonly ApplicationDbContext _context;

        public WonOrLostCaseService( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MyCaseWonOrLost>> GetAllStatusesAsync()
        {
            return await _context.MyCaseWonOrLost.ToListAsync();
        }

        public async Task<MyCaseWonOrLost> GetStatusByIdAsync(int id)
        {
            return await _context.MyCaseWonOrLost.FindAsync(id);
        }

        public async Task AddStatusAsync(MyCaseWonOrLost status)
        {
            _context.MyCaseWonOrLost.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(MyCaseWonOrLost status)
        {
            _context.MyCaseWonOrLost.Update(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatusAsync(int id)
        {
            var status = await _context.MyCaseWonOrLost.FindAsync(id);
            if (status != null)
            {
                _context.MyCaseWonOrLost.Remove(status);
                await _context.SaveChangesAsync();
            }
        }
    }
}
