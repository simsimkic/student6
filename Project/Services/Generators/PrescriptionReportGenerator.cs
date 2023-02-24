using iTextSharp.text;
using iTextSharp.text.pdf;
using Project.Controllers;
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
    class PrescriptionReportGenerator : IReportGenerator<TimeInterval>
    {
        public App app;
        private string rEPORT_RECIPE_PATH;

        public PrescriptionReportGenerator(string rEPORT_RECIPE_PATH)
        {
            app = Application.Current as App;
            this.rEPORT_RECIPE_PATH = rEPORT_RECIPE_PATH;
        }

        public Report Generate(TimeInterval interval)
        {
            Report report = new Report(rEPORT_RECIPE_PATH, new DateTime(), "DoctorAppointment");
            report.Path = rEPORT_RECIPE_PATH + $@"\DoctorReport{report.Id}.pdf";

            Document doc = new Document(PageSize.A4, 10, 10, 40, 35);

            PdfWriter writer = PdfWriter.GetInstance(
                doc, new FileStream(report.Path, FileMode.Create));

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            PatientDTO patientDTO = app.SelectedPatient;

            //List<Prescription> pateintsPresctiption = prescriptionController.GetAllByPatientID(patientDTO.Id);




            List<MedicalAppointmentDTO> list = new List<MedicalAppointmentDTO>();

            doc.Open();
            doc.AddTitle("Doctor Appoitment Repport");
            //Paragraph par = new Paragraph($"Doctor Appoitments from {interval.Start.ToShortDateString()} to {interval.End.ToShortDateString()}");
            Paragraph par = new Paragraph("RECEPAT");

            par.Alignment = Element.ALIGN_CENTER;// ALIGN_LEFT;// ALIGN_MIDDLE;
            par.SetLeading(3, 3);
            par.SpacingAfter = 2;
            doc.Add(par);
            doc.Add(new Chunk("\n"));
            Paragraph par2 = new Paragraph("Lek je odobren od strane lekara Filipa Zdelara, datuma 14/06/2020");


            par2.Alignment = Element.ALIGN_CENTER;// ALIGN_LEFT;// ALIGN_MIDDLE;
            par2.SetLeading(3, 3);
            par2.SpacingAfter = 2;
            doc.Add(par2);
            doc.Add(new Chunk("\n"));
            Paragraph par3 = new Paragraph("Opis lekara");

            par3.Alignment = Element.ALIGN_CENTER;// ALIGN_LEFT;// ALIGN_MIDDLE;
            par3.SetLeading(3, 3);
            par3.SpacingAfter = 2;
            doc.Add(par3);
            doc.Add(new Chunk("\n"));/*
            Paragraph par4 = new Paragraph(description);

            par4.Alignment = Element.ALIGN_CENTER;// ALIGN_LEFT;// ALIGN_MIDDLE;
            doc.Add(par4);
            doc.Add(new Chunk("\n"));
            if (recepies.Count > 0)
            {
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 80;

                table.AddCell(new Phrase("Lek", font));
                table.AddCell(new Phrase("Kolicina", font));
                table.AddCell(new Phrase("Kolicina po danu", font));

                for (int i = 0; i < recepies.Count; i++)
                {
                    var item = recepies.ElementAt(i);

                    string[] rec = item.Split(' ');
                    string medicine = rec[0];
                    string amount = "/";
                    string freq = "/";
                    if (rec.Count() != 1)
                    {
                        string[] af = rec[1].Split('x');
                        if (af.Count() > 1)
                        {
                            if (af[0] != "")
                            {
                                amount = af[0];
                            }
                            freq = af[1];
                        }
                        else
                        {
                            if (af[0] != "")
                            {
                                amount = af[0];
                            }
                        }
                    }
                    table.AddCell(new Phrase(medicine));

                    table.AddCell(new Phrase(amount));
                    table.AddCell(new Phrase(freq));
                }
                doc.Add(table);
            }

            Paragraph par7 = new Paragraph("Potrebno je da svako od pacijenata kontaktira izabranog lekara koji će mu prepisati elektronski recept za duži vremenski period od 6 meseci.Ne mogu ljudi samo da odu do apoteke, a da prethodno nisu dobili elektronski propisanu terapiju kod izabranog lekara.");
            doc.Add(new Chunk("\n"));
            doc.Add(par7);
            */
            doc.Close();


            return report;
        }
    }
}
