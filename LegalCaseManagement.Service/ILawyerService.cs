using LegalCaseManagement.Domain;
using LegalCaseManagement.Data;
using LegalCaseManagement.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface ILawyerService
    {
        Task<bool> UpdateLawyerAsync(Lawyers lawyer);
        Task<List<Lawyers>> GetAllAsync();
    }
}
