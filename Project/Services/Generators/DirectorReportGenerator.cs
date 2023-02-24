using iTextSharp.text;
using iTextSharp.text.pdf;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Generators
{
    class DirectorReportGenerator : IReportGenerator<TimeInterval>
    {
        public App app;
        private string _path;
        private DoctorRepository _doctorRepository;
        private MedicalAppointmentRepository _medicalAppointmentRepository;
        public DirectorReportGenerator(string path, DoctorRepository doctorRepository,MedicalAppointmentRepository medicalAppointmentRepository)
        {
            app = App.Current as App;
            _path = path;
            _doctorRepository = doctorRepository;
            _medicalAppointmentRepository = medicalAppointmentRepository;
        }
        public Report Generate(TimeInterval time)
        {
            
            DateTime CurrentTime = DateTime.Now;
            DateTime Start = time.Start;
            DateTime End = time.End;
            DirectorDTO Director = app.director;
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\Lenovo_NB\\Desktop\\Izvestaj.pdf", FileMode.Create));
            List<Doctor> Doctors = (List<Doctor>)_doctorRepository.GetAll();
            doc.Open();

            doc.Add(new iTextSharp.text.Paragraph($"Bolnica: {Director.Hospital}"));
            doc.Add(new iTextSharp.text.Paragraph($"Datum: {CurrentTime.Day}/{CurrentTime.Month}/{CurrentTime.Year} "));

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("IZVESTAJ O ZAUZETOSTI LEKARA \n");
            paragraph.Alignment = 1;
            doc.Add(paragraph);

            doc.Add(new iTextSharp.text.Paragraph($"Na zahtevu upravnika: {Director.FirstName} {Director.LastName} iz {Director.Address.City} " +
               $"formiran je sledeci izvestaj o zauzetosti lekara u periodu od {Start.Day}.{Start.Month}.{Start.Year} do {End.Day}.{End.Month}.{End.Year}. \n " +
               $"Lekari koji su zaposleni u bolnici {Director.Hospital} su sledeci: \n"));

            for (int i = 0; i < Doctors.Count; i++)
                doc.Add(new iTextSharp.text.Paragraph($"Dr.{Doctors[i].FirstName} {Doctors[i].LastName}"));

                doc.Add(new iTextSharp.text.Paragraph($"\n Termini lekara u periodu od {Start.Day}.{Start.Month}.{Start.Year} do {End.Day}.{End.Month}.{End.Year}. su sledeci: \n"));

            for (int i = 0; i < Doctors.Count; i++)
            {
                List<MedicalAppointment> appointments = getAppointmentsByDoctor(Doctors[i]);
                if (appointments == null)
                    doc.Add(new iTextSharp.text.Paragraph($"Dr.{Doctors[i].FirstName} {Doctors[i].LastName} nema termina u ovom periodu."));
                else
                {
                    doc.Add(new iTextSharp.text.Paragraph($"Dr.{Doctors[i].FirstName} {Doctors[i].LastName}: \n"));
                    PdfPTable table = new PdfPTable(7);
                    table.WidthPercentage = 90;
                    table.AddCell(new Phrase("Red. br"));
                    table.AddCell(new Phrase("Dan"));
                    table.AddCell(new Phrase("Pocetak"));
                    table.AddCell(new Phrase("Kraj"));
                    table.AddCell(new Phrase("Br. Sobe"));
                    table.AddCell(new Phrase("Sprat"));
                    table.AddCell(new Phrase("Tip termina"));
                    int br = 0;
                    for (int j = 0; j < appointments.Count; j++)
                    {
                        if (DateTime.Compare(appointments[j].Beginning, Start) > 0 && DateTime.Compare(appointments[j].End, End) < 0)
                        {
                            br++;
                            DateTime start = appointments[j].Beginning;
                            DateTime end = appointments[j].End;
                            table.AddCell(new Phrase($"{br}."));
                            table.AddCell(new Phrase($"{start.Day}/{start.Month}/{start.Year}"));
                            table.AddCell(new Phrase($"{start.Hour}:{start.Minute}"));
                            table.AddCell(new Phrase($"{end.Hour}:{end.Minute}"));
                            table.AddCell(new Phrase($"{appointments[j].Room.Id}"));
                            table.AddCell(new Phrase($"{appointments[j].Room.Floor}"));
                            if (appointments[j].Type == MedicalAppointmentType.examination)
                                table.AddCell(new Phrase("Pregled"));
                            else
                                table.AddCell(new Phrase($"Operacija"));
                        }
                    }
                    doc.Add(table);
                }
            }
            doc.Close();
            return new Report(_path, CurrentTime, "Upravnik-Zauzetost lekara");
        }
        private List<MedicalAppointment> getAppointmentsByDoctor(Doctor doctor)
        {
            long id = doctor.Id;
            List<MedicalAppointment> appointments = (List<MedicalAppointment>)_medicalAppointmentRepository.GetAll();
            List<MedicalAppointment> doctorsAppointments = new List<MedicalAppointment>();
            foreach (MedicalAppointment medApp in appointments)
            {
                List<Doctor> doctors = (List<Doctor>)medApp.Doctors;
                foreach (Doctor doc in doctors)
                    if (doc.Id == id)
                    {
                        doctorsAppointments.Add(medApp);
                        break;
                    }
            }
            return doctorsAppointments;
        }
    }

}
