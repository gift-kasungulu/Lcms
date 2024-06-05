using LegalCaseManagement.Domain;
using LegalCaseManagement.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface ICaseService
    {
        Task<List<Case>> GetCasesByLawyerIdAsync(int lawyerId);
    }
}
