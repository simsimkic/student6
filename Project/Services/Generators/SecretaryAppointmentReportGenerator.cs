using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Project.Services.Generators
{
    class SecretaryAppointmentReportGenerator : IReportGenerator<TimeInterval>
    {
        public App app;
        private string _path;

        public SecretaryAppointmentReportGenerator(string path)
        {
            app = Application.Current as App;
            _path = path;
        }

        public List<MedicalAppointmentDTO> GetAvailableMedicalAppointments(TimeInterval timeInterval)
        {
            List<MedicalAppointmentDTO> list = app.MedicalAppointmentController.GetAll().ToList();
            List<MedicalAppointmentDTO> returnList = new List<MedicalAppointmentDTO>();
            foreach (MedicalAppointmentDTO item in list)
                if ( item.Beginning.CompareTo(timeInterval.Start) <= 0 || item.End.CompareTo(timeInterval.End) >= 0 )
                    returnList.Add(item);

            return returnList;

        }


        public Report Generate(TimeInterval interval)
        {
            Report report = new Report(_path, new DateTime(), "Appointment");
            report.Path = _path + $@"\AppointmentReport{report.Id}.pdf";

            Document doc = new Document(PageSize.A4, 10, 10, 40, 35);

            PdfWriter writer = PdfWriter.GetInstance(
                doc, new FileStream(report.Path, FileMode.Create));

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            List<MedicalAppointmentDTO> list = GetAvailableMedicalAppointments(interval);

            doc.Open();
            doc.AddTitle("Izveštaj o medicinskim terminima");
            Paragraph par = new Paragraph($"Medicinski termini od {interval.Start.ToShortDateString()} do {interval.End.ToShortDateString()}");
            par.Alignment = Element.ALIGN_CENTER;
            par.SetLeading(5, 5);
            par.SpacingAfter = 20;
            doc.Add(par);

            if (list.Count > 0)
            {
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 80;

                table.AddCell(new Phrase("Id", font));
                table.AddCell(new Phrase("Datum", font));
                table.AddCell(new Phrase("Lekar", font));
                table.AddCell(new Phrase("Pacijent", font));
                table.AddCell(new Phrase("Tip", font));

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list.ElementAt(i);
                    table.AddCell(new Phrase(item.Id.ToString()));
                    table.AddCell(new Phrase(item.Beginning.ToShortTimeString()));
                    table.AddCell(new Phrase(item.Doctors.ElementAt(0).FirstName + " " + item.Doctors.ElementAt(0).LastName));
                    table.AddCell(new Phrase(item.Patient.FirstName + " " + item.Patient.LastName + " " + item.Patient.Jmbg));
                    table.AddCell(new Phrase(item.Type.ToString()));
                }
                doc.Add(table);
            }

            doc.Close();


            return report;
        }
    }
}
