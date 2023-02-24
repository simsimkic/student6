using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AppointmentModal.xaml
    /// </summary>
    public partial class AppointmentModal : Window
    {
        public MedicalAppointmentDTO SelectedAppointment;
        App app;

        public AppointmentModal(MedicalAppointmentDTO dataContext)
        {
            InitializeComponent();
            app = Application.Current as App;
            DataContext = dataContext;

            Date.SelectedDate = (dataContext == null) ? default : dataContext.Beginning;
            var BeginningTerm = (dataContext == null) ? default : dataContext.Beginning;
            var EndTerm = (dataContext == null) ? default : dataContext.End;
            StartTime.Text = BeginningTerm.Hour + ":" + BeginningTerm.Minute;
            EndTime.Text = EndTerm.Hour + ":" + EndTerm.Minute;
            DoctorList.ItemsSource = (dataContext == null) ? default : dataContext.Doctors;
            AllDoctorList.ItemsSource = app.doctors;
            Room.Text = (dataContext == null) ? default : dataContext.Room.Id.ToString();
            SelectedAppointment = dataContext;
            

        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private bool DoctorFilter(object item)
        {
            if (String.IsNullOrEmpty(search.Text))
                return true;
            else
                return ((item as User).FirstName.IndexOf(search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void searchDoctor_TxtChanged(object sended, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(AllDoctorList.ItemsSource).Refresh();

        }

        private void Change_Doctors(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Hidden;
            DoctorList.Visibility = Visibility.Hidden;
            AllDoctorList.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Visible;


        }
        private void Cancel_Change_Doctors(object sender, RoutedEventArgs e)
        {
            search.Visibility = Visibility.Hidden;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            AllDoctorList.Visibility = Visibility.Hidden;
            DoctorList.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
            => new ProfileModal((MedicalAppointmentDTO)(sender as Button).DataContext).Show();

        private void Add_Doctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorDTO item = (DoctorDTO)(sender as System.Windows.Controls.Button).DataContext;
            MessageBox.Show("Da li ste sigurni da zelite da dodate Dr." + item.FirstName + " " + item.LastName + " u termin?", "Potvrda", MessageBoxButton.OKCancel);
            AllDoctorList.Visibility = Visibility.Hidden;
            DoctorList.Visibility = Visibility.Visible;
            Change_Doctor_Button.Visibility = Visibility.Visible;
            Cancel_Change_Doctor_Button.Visibility = Visibility.Hidden;


        }
        private void txtFilter_TextChanged(object sended, RoutedEventArgs e)
        {

        }
        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Room.IsEnabled = true;
            StartTime.IsEnabled = true;
            EndTime.IsEnabled = true;
            Date.IsEnabled = true;
            IzmeniCancel.Visibility = Visibility.Visible;
            ConfirmButton.Visibility = Visibility.Visible;
            Izmeni.Visibility = Visibility.Hidden;

        }
        private void Izmeni_Cancel_Click(object sender, RoutedEventArgs e)
        {
            bool state = false;
            Room.IsEnabled = state;
            StartTime.IsEnabled = state;
            EndTime.IsEnabled = state;
            Date.IsEnabled = state;
            IzmeniCancel.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorDTO doctor = (DoctorDTO)DoctorList.SelectedItem;
            ((DataContext as MedicalAppointmentDTO).Doctors as List<DoctorDTO>).Remove(doctor);
            CollectionViewSource.GetDefaultView(DoctorList.ItemsSource).Refresh();


        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorDTO doctor = (DoctorDTO)AllDoctorList.SelectedItem;
            ((DataContext as MedicalAppointmentDTO).Doctors as List<DoctorDTO>).Add(doctor);
            CollectionViewSource.GetDefaultView(DoctorList.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(AllDoctorList.Items).Refresh();

        }


        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool state = false;
            Room.IsEnabled = state;
            StartTime.IsEnabled = state;
            EndTime.IsEnabled = state;
            Date.IsEnabled = state;
            IzmeniCancel.Visibility = Visibility.Hidden;
            ConfirmButton.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;

        }

        private void Cancel_Appointment_Click(object sender, RoutedEventArgs e)
        {
            app.MedicalAppointmentController.Remove(SelectedAppointment);
            this.Close();

        }
    }
}
