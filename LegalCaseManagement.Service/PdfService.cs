using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.Drawing;
using System.IO;
using LegalCaseManagement.Data;
using LegalCaseManagement.Data.LegalServices;

public class PdfService
{
    public byte[] GeneratePdfFromCases(List<Case> cases)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            // Add a page
            PdfPage page = document.Pages.Add();

            // Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            // Iterate over filtered cases and add their details to the PDF
            float y = 10;
            foreach (var caseItem in cases)
            {
                // Add case details to the PDF
                graphics.DrawString($"{caseItem.CaseId}: {caseItem.Discription}", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, y));
                y += 20;
            }

            // Save the document to the memory stream
            document.Save(stream);

            // Close the document
            document.Close(true);

            // Return the byte array of the PDF content
            return stream.ToArray();
        }
    }
}
