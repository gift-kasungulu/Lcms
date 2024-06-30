using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using LegalCaseManagement.Domain;

public class DocumentService
{
    private readonly HttpClient _httpClient;

    public DocumentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Document[]> GetDocumentsForCase(int caseId)
    {
        return await _httpClient.GetFromJsonAsync<Document[]>($"api/cases/{caseId}/documents");
    }

    public async Task AddDocument(CaseDocument document)
    {
        await _httpClient.PostAsJsonAsync("api/documents", document);
    }

    public async Task UpdateDocument(CaseDocument document)
    {
        await _httpClient.PutAsJsonAsync($"api/documents/{document.Id}", document);
    }

    public async Task DeleteDocument(int documentId)
    {
        await _httpClient.DeleteAsync($"api/documents/{documentId}");
    }
}
