using Project.Views.Model;
using Project.Views.Secretary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views.Tabs
{
    /// <summary>
    /// Interaction logic for SecretaryPatients.xaml
    /// </summary>
    public partial class SecretaryPatients : UserControl
    {
        App app;
        public string JMBG { get; set; }
        public string InsNumber { get; set; }
        public string TextInput { get; set; }
        public GuestDTO Guest { get; set; }
        public SecretaryPatients()
        {

            InitializeComponent();
            app = Application.Current as App;

            PatientList.ItemsSource = app.PatientController.GetAll();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(PatientList.ItemsSource);
            view.Filter = CombinedFilter;
        }
        private bool CombinedFilter(object item)
            => (FirstNameFilter(item) || LastNameFilter(item)) && JMBGFilter(item) && GradFilter(item) && GuestFilter(item);

        private bool FirstNameFilter(object item)
          => (String.IsNullOrEmpty(PatientSearch_TextBox.Text) ||
            (item as PatientDTO).FirstName.IndexOf(PatientSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool LastNameFilter(object item)
          => (String.IsNullOrEmpty(PatientSearch_TextBox.Text) ||
            (item as PatientDTO).LastName.IndexOf(PatientSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        private bool JMBGFilter(object item)
          => (String.IsNullOrEmpty(JMBGSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(JMBGSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool AddressFilter(object item)
          => (String.IsNullOrEmpty(AddressSearch_TextBox.Text) ||
            (item as PatientDTO).Jmbg.IndexOf(AddressSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool GradFilter(object item)
          => (String.IsNullOrEmpty(AddressSearch_TextBox.Text) ||
            (item as PatientDTO).InsurenceNumber.IndexOf(AddressSearch_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool GuestFilter(object item)
          => (GuestFilter_CheckBox.IsChecked == false) ||
            ((item as PatientDTO).Email.Equals("") == false);

        private void JMBGSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();


        private void AddressSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();

        private void GuestFilter_CheckBox_Click(object sender, RoutedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();

        private void PatientSearch_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(PatientList.ItemsSource).Refresh();

        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();
        private void Settings_Click(object sender, RoutedEventArgs e) => new SettingsModal().Show();

        private void CreatePatient_Click(object sender, RoutedEventArgs e) => new RegisterPatient().Show();

        private async void Demo_Click(object sender, RoutedEventArgs e)
        {

            Brush colour = CreatePatientButton.Background;
            await Task.Delay(1000);
            PatientSearch_TextBox.Text = "Darko";
            await Task.Delay(1000);
            PatientSearch_TextBox.Text = "";
            await Task.Delay(1000);
            GuestFilter_CheckBox.IsChecked = true;
            await Task.Delay(1000);
            GuestFilter_CheckBox.IsChecked = false;

            await Task.Delay(1000);
            AddressSearch_TextBox.Text = "23";
            await Task.Delay(1000);
            AddressSearch_TextBox.Text = "";
            await Task.Delay(1000);

            JMBGSearch_TextBox.Text = "23";
            await Task.Delay(1000);
            JMBGSearch_TextBox.Text = "";
            await Task.Delay(1000);


            await Task.Delay(200);
            CreatePatientButton.Background = Brushes.Transparent;
            await Task.Delay(200);
            CreatePatientButton.Background = Brushes.White;
            await Task.Delay(200);
            CreatePatientButton.Background = colour;
            await Task.Delay(1000);


            await Task.Delay(200);
            CreatePatientButton.Background = Brushes.Transparent;
            await Task.Delay(200);
            CreatePatientButton.Background = Brushes.White;
            await Task.Delay(200);
            CreatePatientButton.Background = colour;
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            string id = ((Button)sender).Tag.ToString();
            long i = long.Parse(id);
            PatientDTO pat = app.PatientController.GetById(i);
            new ProfileModal(pat).Show();
        }
    }
}
