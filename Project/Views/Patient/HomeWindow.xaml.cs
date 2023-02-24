using LiveCharts;
using LiveCharts.Wpf;
using Project.Model;
using Project.Views.Model;
using Project.Views.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public ObservableCollection<MedicalAppointmentDTO> Appoitments { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> PastAppoitments { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> AvailableAppoitments { get; set; }
        public PatientDTO LoggedInPatient { get; set; }
        private App app;

        //Chart
        public SeriesCollection SeriesCollection { get; }
        public string[] Labels { get; }
        public Func<double, string> Formatter { get; set; }

        public HomeWindow(string email)
        {
            InitializeComponent();
            this.DataContext = this;
            app = Application.Current as App;

            //Profile
            LoggedInPatient = app.PatientController.GetByEmail(email);

            //Appoitments
        /*    PastAppoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            Appoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();
            var list = app.MedicalAppointmentController.GetAllByPatientID(LoggedInPatient.Id);
            foreach (MedicalAppointmentDTO appoitment in list)
            {
                appoitment.Anamnesis = (List<AnamnesisDTO>)app.AnamnesisController.GetByMedicalAppointmentId(appoitment.Id);
                if (appoitment.Beginning > DateTime.Now){
                    Appoitments.Add(appoitment);
                }
                else{
                    PastAppoitments.Add(appoitment);
                }
            }

            AvailableAppoitments = new ObservableCollection<Model.MedicalAppointmentDTO>();


            //Chart
            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Number of patients currently at hospital",
                    Values = new ChartValues<int> { 10, 50, 39, 50, 67, 35, 10, 55, 65}
                }
            };

            Labels = new[] { "7:00", "8:30", "10:00", "11:30", "13:00", "14:30", "16:00", "17:30", "19:00" };
            Formatter = value => value.ToString("N");
            */

        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.Feedback();
            s.Show();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.FAQ();
            s.Show();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            var tempApp = new List<MedicalAppointmentDTO>();
            foreach(MedicalAppointmentDTO item in PastAppoitments){
                tempApp.Add(item);
            }
            var s = new Patient.History(tempApp);
            s.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.Doctor();
            s.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            firstName.IsEnabled = true;
            lastName.IsEnabled = true;
            birthDate.IsEnabled = true;
            JMBG.IsEnabled = true;
            insuranceNumber.IsEnabled = true;
            gender.IsEnabled = true;
            country.IsEnabled = true;
            city.IsEnabled = true;
            postCode.IsEnabled = true;
            street.IsEnabled = true;
            number.IsEnabled = true;
            email.IsEnabled = true;
            password.IsEnabled = true;
            buttonEdit.IsEnabled = false;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            LoggedInPatient.Password = password.Password;
            app.PatientController.Update(LoggedInPatient);

            firstName.IsEnabled = false;
            lastName.IsEnabled = false;
            birthDate.IsEnabled = false;
            JMBG.IsEnabled = false;
            insuranceNumber.IsEnabled = false;
            gender.IsEnabled = false;
            country.IsEnabled = false;
            city.IsEnabled = false;
            postCode.IsEnabled = false;
            street.IsEnabled = false;
            number.IsEnabled = false;
            email.IsEnabled = false;
            password.IsEnabled = false;
            buttonEdit.IsEnabled = true;
        }

        private void ViewAvailable_Click(object sender, RoutedEventArgs e)
        {

            RoomDTO tempRoom = new RoomDTO() { Floor = "One", Id = 4, Ward = "Check" };
            DoctorDTO tempDoctor = new DoctorDTO() { FirstName = "Filip Zdelar", Address = LoggedInPatient.Address };
            ReviewDTO tempReview = new ReviewDTO(5, "yes");
            List<DoctorDTO> tempDoctors = new List<DoctorDTO>();
            tempDoctors.Add(tempDoctor);
            AvailableAppoitments.Clear();
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Beginning = new DateTime(2020, 5, 10, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0), IsScheduled = false, Room = tempRoom, Patient = LoggedInPatient, Doctors = tempDoctors });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Beginning = new DateTime(2020, 5, 11, 18, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 18, 30, 0), IsScheduled = false, Room = tempRoom, Patient = LoggedInPatient, Doctors = tempDoctors });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Beginning = new DateTime(2020, 5, 12, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0), IsScheduled = false, Room = tempRoom, Patient = LoggedInPatient, Doctors = tempDoctors });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Beginning = new DateTime(2020, 5, 13, 15, 0, 0), Type = MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = false, Room = tempRoom, Patient = LoggedInPatient, Doctors = tempDoctors });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Beginning = new DateTime(2020, 5, 14, 11, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 14, 11, 30, 0), IsScheduled = false, Room = tempRoom, Patient = LoggedInPatient, Doctors = tempDoctors });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Beginning = new DateTime(2020, 5, 15, 14, 0, 0), Type = MedicalAppointmentType.operation, End = new DateTime(2020, 5, 15, 14, 30, 0), IsScheduled = false, Room = tempRoom, Patient = LoggedInPatient, Doctors = tempDoctors });


            ConfirmButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
            ViewAvailableButton.IsEnabled = false;
        }

        private void ConfirmAvailable_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < AvailableAppoitments.Count(); i++)
            {
                if (!AvailableAppoitments[i].IsScheduled)
                {
                    AvailableAppoitments.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 1; i < AvailableAppoitments.Count(); i++)
            {
                if (AvailableAppoitments[i].IsScheduled)
                {
                    AvailableAppoitments.RemoveAt(i);
                    i--;
                }
            }
            app.MedicalAppointmentController.Save(AvailableAppoitments[0]);
            ConfirmButton.IsEnabled = false;
        }

        private void CancelAvailable_Click(object sender, RoutedEventArgs e)
        {
            AvailableAppoitments.Clear();
            ConfirmButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            ViewAvailableButton.IsEnabled = true;
        }

        private void ConfirmAppoitments_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Appoitments.Count(); i++)
            {
                if (!Appoitments[i].IsScheduled)
                {
                    Appoitments.RemoveAt(i);
                    i--;
                }
            }
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            string id = ((Button)sender).Tag.ToString();
            int i = int.Parse(id);
            var s = new Patient.RateAppointment(PastAppoitments[i]);
            s.Show();
        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.GenReport();
            s.Show();
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.AskQuestion(LoggedInPatient);
            s.Show();
        }
    }
}
