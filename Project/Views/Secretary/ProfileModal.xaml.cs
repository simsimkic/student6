using Project.Model;
using Project.Repositories;
using Project.Views.Model;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for ProfileModal.xaml
    /// </summary>
    public partial class ProfileModal : Window
    {

        App app;
        public string FirstAndLastName;
        public string Email { get; set; }
        public string FirstName { get; set; }
        public GuestDTO Guest { get; set; }
        public PatientDTO Patient { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public ProfileModal(MedicalAppointmentDTO dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
            app = Application.Current as App;
            Profile_FirstName.Text = dataContext.Patient.FirstName;
            Profile_LastName.Text = dataContext.Patient.LastName;
            Profile_DateOfBirth.SelectedDate = dataContext.Patient.DateOfBirth;
            ListAppointments.ItemsSource = app.MedicalAppointments.FindAll(item => item.Patient.Id == dataContext.Patient.Id && dataContext.Beginning.CompareTo(new DateTime()) >= 0);
            ListHistory.ItemsSource = app.MedicalAppointments.FindAll(item => item.Patient.Id == dataContext.Patient.Id && dataContext.Beginning.CompareTo(new DateTime()) < 0);
            Guest = dataContext.Patient;
        }
        public ProfileModal(PatientDTO dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
            Profile_FirstName.Text = dataContext.FirstName;
            Profile_LastName.Text = dataContext.LastName;
            Profile_Email.Text = dataContext.Email;
            Profile_DateOfBirth.SelectedDate = dataContext.DateOfBirth;
            Guest = dataContext;
            Patient = dataContext;
        }

        private void HandleEsc(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
            Close();
    }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = true;
            Profile_LastName.IsEnabled = true;
            Profile_Email.IsEnabled = true;
            Profile_DateOfBirth.IsEnabled = true;
            Obustavi.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Visible;
            Izmeni.Visibility = Visibility.Hidden;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = false;
            Profile_LastName.IsEnabled = false;
            Profile_Email.IsEnabled = false;
            Profile_DateOfBirth.IsEnabled = false;
            Obustavi.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;
            Profile_FirstName.Text = (DataContext as PatientDTO).FirstName;
            Profile_LastName.Text = (DataContext as PatientDTO).LastName;
            Profile_DateOfBirth.SelectedDate = (DataContext as PatientDTO).DateOfBirth;
            Profile_Email.Text = (DataContext as PatientDTO).Email;

        }

        private void listAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = false;
            Profile_LastName.IsEnabled = false;
            Profile_Email.IsEnabled = false;
            Profile_DateOfBirth.IsEnabled = false;
            Obustavi.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;
        }

        private void Claim_Click(object sender, RoutedEventArgs e)
            => new ClaimAccount(Guest).Show();

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            var url = "mailto:" + Patient.Email;
            Process.Start(url);
        }
    }
}
