using LegalCaseManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LegalCaseManagement.Service
{
    public interface IDocumentService
    {
        //Task<List<CaseDocument>> GetDocumentsForCaseAsync(int caseId);
        Task AddDocumentAsync(CaseDocument document);
        Task UpdateDocumentAsync(CaseDocument document);
        Task DeleteDocumentAsync(int documentId);
    }
}
