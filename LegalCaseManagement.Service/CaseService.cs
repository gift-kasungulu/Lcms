﻿using LegalCaseManagement.Service;
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
        public async Task<bool> MarkCaseAsWonAsync(int caseId)
        {
            var caseToUpdate = await _context.Cases.FindAsync(caseId);
            if (caseToUpdate == null) return false;

            caseToUpdate.CaseStatus.StatusName = "Won";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkCaseAsLostAsync(int caseId)
        {
            var caseToUpdate = await _context.Cases.FindAsync(caseId);
            if (caseToUpdate == null) return false;

            caseToUpdate.CaseStatus.StatusName = "Lost";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Case>> GetCasesByLawyerIdAsync(string lawyerId)
        {
            return await _context.Cases
                .Where(c => c.UserId == lawyerId)
                .Include(c => c.AppUser)
                .Include(c => c.CaseStatus)
                .Include(c => c.CaseType)
                .ToListAsync();
        }
        public async Task<Case> GetByIdAsync(int id)
        {
            return await _context.Cases
                .Include(c => c.CaseType)
                .Include(c => c.CaseStatus)
                .Include(c => c.AppUser)
                .Include(c => c.CaseDocuments) // Include documents
                .FirstOrDefaultAsync(c => c.CaseId == id);
        }
        public async Task<int> GetCasesCreatedCountByLawyerAsync(string lawyerId)
        {
            return await _context.Cases.CountAsync(c => c.CreatedByUserId == lawyerId);
        }

        public async Task<int> GetCasesAssignedCountByLawyerAsync(string lawyerId)
        {
            return await _context.Cases.CountAsync(c => c.AssignedLawyerId == lawyerId);
        }
    }
}
