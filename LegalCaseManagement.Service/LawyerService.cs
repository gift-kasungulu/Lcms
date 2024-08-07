﻿using LegalCaseManagement.Data;
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
                // Find related tasks
                var tasks = _context.MyTasks.Where(t => t.LawyerId == lawyer.Id).ToList();

                // Remove related tasks
                _context.MyTasks.RemoveRange(tasks);

                // Remove the lawyer
                _context.Lawyers.Remove(lawyer);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

