using LegalCaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReportService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ReportService(ApplicationDbContext applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
    }

    public async Task<string> GenerateAbandonedCasesReportAsync()
    {
        var abandonedCases = await _applicationDbContext.Cases
            .Include(c => c.CaseStatus) // Ensure CaseStatus navigation property is included
            .Where(c => c.CaseStatus.StatusName == "Abandoned" && c.StartDate != null && c.StartDate.Value.Month == DateTime.Now.Month)
            .ToListAsync();

        var reportContent = FormatCasesReport(abandonedCases);
        return reportContent;
    }

    public async Task<string> GenerateCompletedCasesReportAsync()
    {
        // Fetch and generate completed cases report logic
        // Example:
        var completedCases = await _applicationDbContext.Cases
            .Where(c => c.CaseStatus.StatusName == "Completed" && c.EndDate.Value.Month == DateTime.Now.Month)
            .ToListAsync();
        return FormatCasesReport(completedCases);
    }


    public async Task<string> GenerateRunningCasesReportAsync()
    {
        var runningCases = await _applicationDbContext.Cases
            .Include(c => c.CaseStatus) // Ensure CaseStatus navigation property is included
            .Where(c => c.CaseStatus.StatusName == "Running" && c.StartDate != null && c.StartDate.Value.Month == DateTime.Now.Month)
            .ToListAsync();

        var reportContent = FormatCasesReport(runningCases);
        return reportContent;
    }

    private string FormatCasesReport(List<Case> cases)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<h3>Monthly Cases Report</h3>");
        sb.AppendLine("<ul>");

        foreach (var caseItem in cases)
        {
            sb.AppendLine($"<li>{caseItem.Discription} - {caseItem.CaseStatus.StatusName}</li>");
        }

        sb.AppendLine("</ul>");
        return sb.ToString();
    }
}
