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
            .Where(c => c.RegistrationDate >= startDate && c.RegistrationDate <= endDate)
            .Include(c => c.CaseStatus) // Ensure CaseStatus is loaded
            .Include(c => c.CaseType) // include win or lost caess
            .ToListAsync();

        // Log or debug output to verify data
        Console.WriteLine($"Total cases fetched: {cases.Count}");

        var completedCases = cases.Where(c => c.CaseStatus.StatusName == "Completed").ToList();
        var wonCases = cases.Where(c => c.CaseType.TypeName == "Won").ToList(); // for won casese
        var lostCases = cases.Where(c => c.CaseType.TypeName == "Lost").ToList(); // for Lost cases

        // Log the counts
        Console.WriteLine($"Completed Cases: {completedCases.Count}");
        Console.WriteLine($"Won Cases: {wonCases.Count}");
        Console.WriteLine($"Lost Cases: {lostCases.Count}");

        return new MonthlyReport
        {
            TotalCases = cases.Count,
            CompletedCases = completedCases.Count,
            WonCases = wonCases.Count,
            LostCases = lostCases.Count
        };
    }

    public async Task<byte[]> GeneratePdfReportAsync(DateTime month, int totalCases, int completedCases, int wonCases, int lostCases)
    {
        using (var ms = new MemoryStream())
        {
            using (var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50))
            {
                try
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    document.Open();

                    // Add title
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    document.Add(new Paragraph($"Monthly Case Report - {month:MMMM yyyy}", titleFont) { Alignment = Element.ALIGN_CENTER });
                    document.Add(Chunk.NEWLINE);

                    // Add summary table
                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 100;

                    AddTableRow(table, "Total Cases:", totalCases.ToString());
                    AddTableRow(table, "Completed Cases:", completedCases.ToString());
                    AddTableRow(table, "Won Cases:", wonCases.ToString());
                    AddTableRow(table, "Lost Cases:", lostCases.ToString());

                    document.Add(table);
                    document.Add(Chunk.NEWLINE);

                    // Add percentages
                    if (totalCases > 0)
                    {
                        document.Add(new Paragraph($"Completion Rate: {(double)completedCases / totalCases:P2}"));
                    }
                    if (completedCases > 0)
                    {
                        document.Add(new Paragraph($"Win Rate: {(double)wonCases / completedCases:P2}"));
                        document.Add(new Paragraph($"Loss Rate: {(double)lostCases / completedCases:P2}"));
                    }

                    document.Close();
                }
                catch (DocumentException de)
                {
                    throw new ApplicationException("Error creating PDF document", de);
                }
            }

            return ms.ToArray();
        }
    }

    private void AddTableRow(PdfPTable table, string label, string value)
    {
        var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
        table.AddCell(new PdfPCell(new Phrase(label, cellFont)) { Border = PdfPCell.NO_BORDER });
        table.AddCell(new PdfPCell(new Phrase(value, cellFont)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
    }

    public class MonthlyReport
    {
        public int TotalCases { get; set; }
        public int CompletedCases { get; set; }
        public int WonCases { get; set; }
        public int LostCases { get; set; }
    }
}
