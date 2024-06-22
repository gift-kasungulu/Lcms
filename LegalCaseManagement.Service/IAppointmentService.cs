using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface IAppointmentService
    {
        Task AddAppointment(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<ApplicationUser>> GetClients();
        Task DeleteAppointment(int id);
        Task<Appointment> GetAppointmentById(int id);
    }
}
