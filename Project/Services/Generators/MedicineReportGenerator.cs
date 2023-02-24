using iTextSharp.text;
using iTextSharp.text.pdf;
using Project.Model;
using Project.Repositories;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Generators
{
    class MedicineReportGenerator : IReportGenerator<TimeInterval>
    {
        public App app;
        private string _path;
        private MedicineRepository _medicineRepository;

        public MedicineReportGenerator(string path, MedicineRepository medicineRepository)
        {
            app = App.Current as App;
            _path = path;
            _medicineRepository = medicineRepository;
        }

        public Report Generate(TimeInterval time)
        {
            DateTime CurrentTime = DateTime.Now;
            DirectorDTO Director = app.director;
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Lenovo_NB\\Desktop\\IzvestajLekovi.pdf", FileMode.Create));
            List<Medicine> medicines = (List<Medicine>)_medicineRepository.GetAll();
            doc.Open();

            doc.Add(new iTextSharp.text.Paragraph($"Bolnica: {Director.Hospital}"));
            doc.Add(new iTextSharp.text.Paragraph($"Datum: {CurrentTime.Day}/{CurrentTime.Month}/{CurrentTime.Year} "));

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("IZVESTAJ O RASPOLOZIVIM LEKOVIMA \n");
            paragraph.Alignment = 1;
            doc.Add(paragraph);

            doc.Add(new iTextSharp.text.Paragraph($"Na zahtevu upravnika: {Director.FirstName} {Director.LastName} iz {Director.Address.City} " +
               $"formiran je sledeci izvestaj o raspolozivim lekovima za dan {CurrentTime.Day}.{CurrentTime.Month}.{CurrentTime.Year}. \n " +
               $"Lekovi koji su registrovani u bolnici {Director.Hospital} su sledeci: \n"));

            for (int i = 0; i < medicines.Count; i++)
                doc.Add(new iTextSharp.text.Paragraph($"{medicines[i].Name}"));

            doc.Add(new iTextSharp.text.Paragraph($"\n Detaljno: \n \n"));

            PdfPTable table = new PdfPTable(8);
            table.WidthPercentage = 100;
            table.AddCell(new Phrase("Red. br"));
            table.AddCell(new Phrase("Naziv"));
            table.AddCell(new Phrase("Opis"));
            table.AddCell(new Phrase("Tip"));
            table.AddCell(new Phrase("Namena"));
            table.AddCell(new Phrase("Nacin upotrebe"));
            table.AddCell(new Phrase("Kolicina"));
            table.AddCell(new Phrase("Stanje"));
            for (int i = 0; i < medicines.Count; i++)
            {
                table.AddCell(new Phrase($"{i + 1}."));
                table.AddCell(new Phrase($"{medicines[i].Name}"));
                table.AddCell(new Phrase($"{medicines[i].Description}"));
                table.AddCell(new Phrase($"{medicines[i].Type}"));
                table.AddCell(new Phrase($"{medicines[i].Purpose}"));
                table.AddCell(new Phrase($"{medicines[i].Administration}"));
                table.AddCell(new Phrase($"{medicines[i].Quantity}"));
                if (medicines[i].Approved)
                    table.AddCell(new Phrase($"Odobren"));
                else
                    table.AddCell(new Phrase($"Nije odobren"));
            }
            doc.Add(table);
            doc.Close();
            return new Report(_path, CurrentTime, "Upravnik-Zauzetost lekara");
        }
    }
}

