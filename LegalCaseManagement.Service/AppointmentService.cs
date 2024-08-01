using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EmailService _emailService;

        public AppointmentService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, EmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task AddAppointment(Appointment appointment)
        {
            // Ensure ClientName is not null before saving
            if (string.IsNullOrEmpty(appointment.ClientName))
            {
                throw new ArgumentException("ClientName must be set before saving the appointment.");
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Send email notification
            await _emailService.SendAppointmentNotificationAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _context.Appointments.Include(a => a.User).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetClients()
        {
            var users = await _context.Users.ToListAsync();
            var clients = new List<ApplicationUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Client"))
                {
                    clients.Add(user);
                }
            }

            return clients;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.Appointments.AsQueryable();
            if (fromDate.HasValue)
                query = query.Where(a => a.Date >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(a => a.Date <= toDate.Value);
            return await query.Include(a => a.User).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _context.Appointments
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByClient(string userId)
        {
            return await _context.Appointments.Where(a => a.UserId == userId && a.IsApproved).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByTeamMember(string userId)
        {
            return await _context.Appointments.Where(a => a.CreatedBy == userId && a.IsApproved).ToListAsync();
        }

        public async Task<IEnumerable<Lawyers>> GetLawyers()
        {
            return await _context.Set<Lawyers>().ToListAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        // New methods for managing appointment approval status
        public async Task<IEnumerable<Appointment>> GetPendingAppointments()
        {
            return await _context.Appointments
                .Where(a => !a.IsApproved)
                .Include(a => a.User)
                .ToListAsync();
        }

        public async Task ApproveAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null && !appointment.IsApproved)
            {
                appointment.IsApproved = true;
                await _context.SaveChangesAsync();

                // Optionally, send an email notification about the approval
                //await _emailService.SendAppointmentApprovalNotificationAsync(appointment);
            }
        }
    }
}
