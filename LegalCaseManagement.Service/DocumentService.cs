using LegalCaseManagement.Data;
using LegalCaseManagement.Domain;
using LegalCaseManagement.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public class DocumentService : IDocumentService
{
    private readonly ApplicationDbContext _context;

    public DocumentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddDocumentAsync(CaseDocument document)
    {
        _context.Documents.Add(document);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDocumentAsync(CaseDocument document)
    {
        _context.Documents.Update(document);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDocumentAsync(int documentId)
    {
        var document = await _context.Documents.FindAsync(documentId);
        if (document != null)
        {
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}
