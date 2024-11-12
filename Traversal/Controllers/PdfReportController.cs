using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Pdf Rapor");
            document.Add(paragraph);
            document.Close();

            return File("/pdfReports/dosya2.pdf","application/pdf","dosya1.pdf");
        }

    

     public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");
            pdfPTable.AddCell("Asel");
            pdfPTable.AddCell("KAYA");
            pdfPTable.AddCell("22222222222");
            pdfPTable.AddCell("Hatice");
            pdfPTable.AddCell("KAYA");
            pdfPTable.AddCell("32222222222");
            document.Add(pdfPTable);
            document.Close();

            return File("/pdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }

    }
}