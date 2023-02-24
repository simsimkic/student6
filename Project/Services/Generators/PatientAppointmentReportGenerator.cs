using iTextSharp.text;
using iTextSharp.text.pdf;
using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Services.Generators
{
    class PatientAppointmentReportGenerator : IReportGenerator<TimeInterval>
    {     
        public App app;
        private string _path;

        public PatientAppointmentReportGenerator(string path)
        {
            app = Application.Current as App;
            _path = path;
        }


        public Report Generate(TimeInterval interval)
        {
            Report report = new Report(_path, new DateTime(), "PatinetAppointment");
            report.Path = _path + $@"\PatientReport{report.Id}.pdf";

            Document doc = new Document(PageSize.A4, 10, 10, 40, 35);

            PdfWriter writer = PdfWriter.GetInstance(
                doc, new FileStream(report.Path, FileMode.Create));

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            App app = Application.Current as App;
            List<MedicalAppointmentDTO> list = (List<MedicalAppointmentDTO>)app.MedicalAppointmentController.GetAllByPatientID(app.currentUser.Id);


            for(int i = 0; i < list.Count; i++)
            {
                if((list[i].Beginning < interval.Start) || (list[i].Beginning > interval.End)){
                    list.RemoveAt(i);
                    i--;
                }
            }
            

            doc.Open();
            doc.AddTitle("Patient Appoitment Report");
            Paragraph par = new Paragraph($"Patient Appoitments from {interval.Start.ToShortDateString()} to {interval.End.ToShortDateString()}");
            par.Alignment = Element.ALIGN_CENTER;
            par.SetLeading(5, 5);
            par.SpacingAfter = 20;
            doc.Add(par);

            if (list.Count > 0)
            {
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 80;

                table.AddCell(new Phrase("Type", font));
                table.AddCell(new Phrase("Doctor", font));
                table.AddCell(new Phrase("Room", font));
                table.AddCell(new Phrase("Begining", font));
                table.AddCell(new Phrase("End", font));

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list.ElementAt(i);
                    table.AddCell(new Phrase(item.Type.ToString()));
                    table.AddCell(new Phrase(item.Doctors.ElementAt(0).FirstName + " " + item.Doctors.ElementAt(0).LastName));
                    table.AddCell(new Phrase(item.Room.Floor + " " + item.Room.Id));
                    table.AddCell(new Phrase(item.Beginning.ToString()));
                    table.AddCell(new Phrase(item.End.ToString()));
                }
                doc.Add(table);
            }


            doc.Close();


            return report;
        }
    }
}
