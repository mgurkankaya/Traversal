using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Traversal.Models;

namespace Traversal.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult StaticExcelReport()
    {
        ExcelPackage excelPackage = new ExcelPackage();
        var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");
        workSheet.Cells[1, 1].Value = "Rota";
        workSheet.Cells[1, 2].Value = "Rehber";
        workSheet.Cells[1, 3].Value = "Kontenjan";

        workSheet.Cells[2, 1].Value = "Bangkok turu";
        workSheet.Cells[2, 2].Value = "Ahmet Mehmet";
        workSheet.Cells[2, 3].Value = "30";

        workSheet.Cells[3, 1].Value = "Moskova turu";
        workSheet.Cells[3, 2].Value = "Ali Veli";
        workSheet.Cells[3, 3].Value = "30";

        var bytes = excelPackage.GetAsByteArray();

        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");
    }

    public List<DestinationModel> destinationList()
    {
        List<DestinationModel> destinationModels = new List<DestinationModel>();
        using (var c = new Context())
        {
            destinationModels = c.Destinations.Select(x => new DestinationModel
            {
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price,
                Capacity = x.Capacity
            }).ToList();
        }
        return destinationModels;

    }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in destinationList())
                {
                    rowCount++;
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                }

                using (var stream = new MemoryStream())
                        {

                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");

                }

            }
        }


    }
}
