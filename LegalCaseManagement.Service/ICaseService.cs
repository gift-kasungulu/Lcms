using LegalCaseManagement.Domain;
using LegalCaseManagement.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface ICaseService
    {
        Task<List<Case>> GetCasesByLawyerIdAsync(string  lawyerId);

        Task<Case> GetByIdAsync(int id);
        Task<bool> MarkCaseAsWonAsync(int caseId);
        Task<bool> MarkCaseAsLostAsync(int caseId);
    }
}
