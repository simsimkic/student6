using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using Project.Views.Model;

namespace Project.Views.Patient
{
    public partial class Doctor : Window
    {
        public DoctorDTO SelectedDoctor { get; set; }
        public ObservableCollection<MedicalAppointmentDTO> AvailableAppoitments { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public Doctor()
        {
            InitializeComponent();
            this.DataContext = this;


            //list of appotments for this doctor and where the logged in patient is scheguled
            List<MedicalAppointmentDTO> tempAppointments = new List<MedicalAppointmentDTO>();
            RoomDTO tempRoom = new RoomDTO() { Floor = "two", Type = Project.Model.RoomType.medicalRoom, Ward = "op" };
            tempAppointments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0), IsScheduled = true });
            tempAppointments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 15, 30, 0), IsScheduled = true });
            tempAppointments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0), IsScheduled = true });
            tempAppointments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = true });
            tempAppointments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 14, 15, 30, 0), IsScheduled = true });
            SelectedDoctor = new DoctorDTO() { Appointments = tempAppointments, FirstName = "Filip", LastName = "Zdelar", AverageReviewScore = 4.5F};

            //list of available medical appoitments for the selected period nad this doctor
            AvailableAppoitments = new ObservableCollection<MedicalAppointmentDTO>();


            //Chart initilization
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries()
                {
                    Title = "Rating",
                    Values = new ChartValues<int> { 3, 2, 2, 10, 13}
                }
            };


            Labels = new[] { "1", "2", "3", "4", "5"};
            Formatter = value => value.ToString("N");

        }



        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < SelectedDoctor.Appointments.Count(); i++)
            {
                if (!SelectedDoctor.Appointments[i].IsScheduled)
                {
                    SelectedDoctor.Appointments.RemoveAt(i);
                    i--;
                }
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < AvailableAppoitments.Count(); i++)
            {
                if (!AvailableAppoitments[i].IsScheduled)
                {
                    AvailableAppoitments.RemoveAt(i);
                    i--;
                }
            }

            //TEMP FOR CONTROLLER TO DO
            for (int i = 1; i < AvailableAppoitments.Count(); i++)
            {
                if (AvailableAppoitments[i].IsScheduled)
                {
                    AvailableAppoitments.RemoveAt(i);
                    i--;
                }
            }
            ConfirmButton.IsEnabled = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AvailableAppoitments.Clear();
            ConfirmButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            ViewAvailableButton.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO tempRoom = new RoomDTO() { Floor = "two", Type = Project.Model.RoomType.medicalRoom, Ward = "op" };
            AvailableAppoitments.Clear();
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 10, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 10, 15, 30, 0), IsScheduled = false });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 11, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 11, 15, 30, 0), IsScheduled = false });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 12, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 12, 15, 30, 0), IsScheduled = false });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 13, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 13, 15, 30, 0), IsScheduled = false });
            AvailableAppoitments.Add(new MedicalAppointmentDTO() { Room = tempRoom, Beginning = new DateTime(2020, 5, 14, 15, 0, 0), Type = Project.Model.MedicalAppointmentType.examination, End = new DateTime(2020, 5, 14, 15, 30, 0), IsScheduled = false });
            ConfirmButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
            ViewAvailableButton.IsEnabled = false;
        }
    }

}
