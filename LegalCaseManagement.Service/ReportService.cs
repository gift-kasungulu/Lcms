using iTextSharp.text;
using iTextSharp.text.pdf;
using LegalCaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class ReportService
{
    private readonly ApplicationDbContext _context;

    public ReportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MonthlyReport> GenerateMonthlyReportAsync(DateTime month)
    {
        var startDate = new DateTime(month.Year, month.Month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        var cases = await _context.Cases
            .Where(c => c.StartDate >= startDate && c.StartDate <= endDate)
            .ToListAsync();

        return new MonthlyReport
        {
            TotalCases = cases.Count,
            CompletedCases = cases.Count(c => c.CaseStatus.StatusName == "Completed"),
            WonCases = cases.Count(c => c.CaseStatus.StatusName == "Won"),
            LostCases = cases.Count(c => c.CaseStatus.StatusName == "Lost")
        };
    }

    public async Task<byte[]> GeneratePdfReportAsync(DateTime month, int totalCases, int completedCases, int wonCases, int lostCases)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (iTextSharp.text.Document document = new iTextSharp.text.Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                document.Add(new Paragraph($"Monthly Report for {month:MMMM yyyy}"));
                document.Add(new Paragraph($"Total Cases: {totalCases}"));
                document.Add(new Paragraph($"Completed Cases: {completedCases}"));
                document.Add(new Paragraph($"Won Cases: {wonCases}"));
                document.Add(new Paragraph($"Lost Cases: {lostCases}"));

                document.Close();
            }

            return ms.ToArray();
        }
    }
}

public class MonthlyReport
{
    public int TotalCases { get; set; }
    public int CompletedCases { get; set; }
    public int WonCases { get; set; }
    public int LostCases { get; set; }
}
