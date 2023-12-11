using CallClient2023Web.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace CallClient2023Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext _context;

        public HomeController(DataBaseContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> LoginForm()
        {
            return View();
        }


        public IActionResult CheckPassword(CallClientModel lozinka)
        {
            var checklozinka = _context.Anketaweb.Where(x => x.KodAnketara == lozinka.KodAnketara).FirstOrDefault();

            if (checklozinka == null) { return View("LoginForm"); }
            else { return RedirectToAction("Index"); }

        }





        public IActionResult Index()
        {
            List<BazaBrojeva> bazabrojeva = _context.BazaBrojeva
                .OrderBy(x => x.BrojTelefona)
                .ToList();

            return View(bazabrojeva);
        }




        public IActionResult Searching(string searchString)
        {
            ViewData["Pretrazivanje"] = searchString;

            var kupci = from kupac in _context.BazaBrojeva
                        select kupac;
            if (!String.IsNullOrEmpty(searchString))
            {
                kupci = kupci.Where(m => m.ImePrezime.Contains(searchString));
                                     
                return View(kupci);
            }

            var kupciList = _context.BazaBrojeva.ToList();
            return View(kupciList);

        }



        public IActionResult OdgovoriForm(int id)
        {
            var odgovoriform = _context.BazaBrojeva.Find(id);
            
            return View(odgovoriform);
        }

        public IActionResult Odgovori(int id, BazaBrojeva dodajodgovor)
        {
            _context.Update(dodajodgovor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<FileResult> ExportExcel()
        {
            var people = await _context.BazaBrojeva.ToListAsync();
            var fileName = "Excel.xlsx";
            return GenerateExcel(fileName, people);
        }




        private FileResult GenerateExcel(string fileName, IEnumerable<BazaBrojeva> people)
        {
            DataTable dataTable = new DataTable("Test");
            dataTable.Columns.AddRange(new DataColumn[]
            {

                new DataColumn("Ime i prezime"),
                new DataColumn("Broj telefona"),
                new DataColumn("Adresa stanovanja"),
                new DataColumn("Asortiman"),
                new DataColumn("Proizvod"),
                new DataColumn("Broj komada"),
                new DataColumn("Članstvo")



            });

            foreach (var person in people)
            {
                dataTable.Rows.Add(person.ImePrezime, person.BrojTelefona, person.AdresaStanovanja, person.AsortimanProizvoda, person.Proizvod, person.BrojKomada, person.Clanstvo);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }

        }
    }
}
