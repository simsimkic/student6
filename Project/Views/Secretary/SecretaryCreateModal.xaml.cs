using Project.Controllers;
using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryCreateModal.xaml
    /// </summary>
    public partial class SecretaryCreateModal : Window
    {
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        public string Name;
        public string Jmbg;

        App app;
        public SecretaryCreateModal()
        {
            InitializeComponent();

            app = System.Windows.Application.Current as App;

            SelectedDate.SelectedDate = app.SelectedDate;

            if (app.SelectedDoctor != null)
                ListTerms.ItemsSource = app.MedicalAppointmentController.GetAvailableAppoitments(app.SelectedDoctor, null, new TimeInterval(DateTime.Now, DateTime.Now.AddDays(1)));
            else
                ListTerms.ItemsSource = new List<MedicalAppointment>();

            ListPatients.ItemsSource = app.PatientController.GetAll();
            ListRooms.ItemsSource = app.RoomController.GetAll();
            AppointmentType.ItemsSource = app.medicalAppointmentTypes;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListPatients.ItemsSource);
            CollectionView roomView = (CollectionView)CollectionViewSource.GetDefaultView(ListRooms.ItemsSource);

            view.Filter = CombinedFilter;
            roomView.Filter = RoomFilter;


        }
        private bool CombinedFilter(object item)
            => (FirstNameFilter(item) || LastNameFilter(item)) && JMBGFilter(item);
        private bool FirstNameFilter(object item)
          => (String.IsNullOrEmpty(FirstNameSearch_TextBox.Text) ||
            (item as PatientDTO).FirstName.IndexOf(FirstNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool LastNameFilter(object item)
          => (String.IsNullOrEmpty(FirstNameSearch_TextBox.Text) ||
            (item as PatientDTO).LastName.IndexOf(FirstNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool JMBGFilter(object item)
          => (String.IsNullOrEmpty(JMBGSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(FirstNameSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool TermFilter(object item)
          => (String.IsNullOrEmpty(SelectedDate.SelectedDate.ToString())) ||
           (item as TimeInterval).Start.Equals(SelectedDate.SelectedDate) == false;

        private bool RoomFilter(object item)
          => (String.IsNullOrEmpty(RoomSearch_TextBox.Text) ||
            (item as RoomDTO).Id.ToString().IndexOf(RoomSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        private void FirstNameSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();


        private void JMBGSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListPatients.ItemsSource).Refresh();

        private void RoomNumber_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(ListRooms.ItemsSource).Refresh();
        private void SelectedDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) { }
            //=> CollectionViewSource.GetDefaultView(ListTerms.ItemsSource).Refresh();

        private void AppointmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Cancel_Guest_Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Create_Guest_Button_Click(object sender, RoutedEventArgs e) => new RegisterGuest().Show();
        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();

        private void Search_Doctor(object sender, RoutedEventArgs e) => new DoctorSearchModal().Show();

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointmentDTO appl = new MedicalAppointmentDTO();
            appl.Patient = ListPatients.SelectedItem as PatientDTO;
            appl.Beginning = (ListTerms.SelectedItem as TimeInterval).Start;
            appl.End = (ListTerms.SelectedItem as TimeInterval).End;
            appl.End = (ListTerms.SelectedItem as TimeInterval).End;
            appl.Room = ListRooms.SelectedItem as RoomDTO;
            appl.Type = (MedicalAppointmentType) AppointmentType.SelectedItem;
            
            List<DoctorDTO> list = new List<DoctorDTO>();
            list.Add(app.SelectedDoctor);
            appl.Doctors = list;

            app.MedicalAppointmentController.Save(appl);


        }


        private void StartDateTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EndDateTime_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListPatients_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
            => app.SelectedPatient = (e.Key == Key.Return) ? (ListPatients.SelectedItem as PatientDTO) : null;
        private async void DemoButton_Click(object sender, RoutedEventArgs e)
        {

            Brush colour = Guest_Button.Background;
            await Task.Delay(1000);
            FirstNameSearch_TextBox.Text = "Petar";
            await Task.Delay(1000);
            FirstNameSearch_TextBox.Text = "";
            JMBGSearch_TextBox.Text = "1603995212533";
            await Task.Delay(2000);
            JMBGSearch_TextBox.Text = "";
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.Transparent;
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.White;
            await Task.Delay(200);
            Guest_Button.Background =  colour;
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.Transparent;
            await Task.Delay(200);
            Guest_Button.Background =  Brushes.White;
            await Task.Delay(200);
            Guest_Button.Background =  colour;
            await Task.Delay(200);
            var s = new RegisterGuest();
            s.Show();
            await Task.Delay(2000);
            s.Close();
            await Task.Delay(200);
            AppointmentType.Background = Brushes.Transparent;
            await Task.Delay(200);
            AppointmentType.Background = Brushes.White;
            await Task.Delay(200);
            AppointmentType.Background = Brushes.Transparent;
            await Task.Delay(200);
            AppointmentType.Background = Brushes.White;

            await Task.Delay(200);
            ListTerms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListTerms.Background = Brushes.White;
            await Task.Delay(200);
            ListTerms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListTerms.Background = Brushes.White;

            await Task.Delay(200);
            SelectedDate.Background = Brushes.Transparent;
            await Task.Delay(200);
            SelectedDate.Background = Brushes.White;
            await Task.Delay(200);
            SelectedDate.Background = Brushes.Transparent;
            await Task.Delay(200);
            SelectedDate.Background = Brushes.White;
            await Task.Delay(200);

            await Task.Delay(200);
            RoomSearch_TextBox.Text = "135";
            await Task.Delay(200);

            await Task.Delay(200);
            ListRooms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListRooms.Background = Brushes.White;
            await Task.Delay(200);
            ListRooms.Background = Brushes.Transparent;
            await Task.Delay(200);
            ListRooms.Background = Brushes.White;
            await Task.Delay(200);

            await Task.Delay(200);
            CreateButton.Background = Brushes.Transparent;
            await Task.Delay(200);
            CreateButton.Background = Brushes.White;
            await Task.Delay(200);
            CreateButton.Background =  colour;
            await Task.Delay(200);
            CreateButton.Background = Brushes.Transparent;
            await Task.Delay(200);
            CreateButton.Background = Brushes.White;
            await Task.Delay(200);
            CreateButton.Background =  colour;
            


        }

    }
}
