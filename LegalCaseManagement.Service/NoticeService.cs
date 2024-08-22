using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public class NoticeService
    {
        private readonly ApplicationDbContext _context;

        public NoticeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notice>> GetAllNoticesAsync()
        {
            return await _context.Notices.ToListAsync();
        }

        public async Task AddNoticeAsync(Notice notice)
        {
            _context.Notices.Add(notice);
            await _context.SaveChangesAsync();
        }

        public async Task<Notice?> GetNoticeByIdAsync(int id)
        {
            return await _context.Notices.FindAsync(id);
        }
    }

}
