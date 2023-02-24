using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using Project.Views.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views.Tabs
{
    /// <summary>
    /// Interaction logic for SecretaryAppointments.xaml
    /// </summary>
    public partial class SecretaryAppointments : System.Windows.Controls.UserControl
    {
        public App app { get; set; }
        public List<MedicalAppointmentDTO> list;
        public DateTime CurrentDate { get; set; }
        public SecretaryAppointments()
        {
            InitializeComponent();
            app = System.Windows.Application.Current as App;
            CurrentDoctor.Content = app.SelectedDoctor;

            AppointmentList.ItemsSource = new List<MedicalAppointmentDTO>();
            //nextAppointment.Content = app.MedicalAppointmentController.GetAll().ToList()[0];

            CurrentDate = app.SelectedDate;
            SelectedDatePick.SelectedDate = CurrentDate;

            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource);
            //view.Filter = CombinedFilter;
        }
        private bool CombinedFilter(object item)
            => DoctorFilter(item) && DateFilter(item);
        private bool DoctorFilter(object item)
          => (app.SelectedDoctor == null) ||
            (item as MedicalAppointmentDTO).Doctors.Contains(app.SelectedDoctor);
        private bool DateFilter(object item)
          => (item as MedicalAppointmentDTO).Beginning.Date.Equals(SelectedDatePick.SelectedDate);

        private void Search_Doctor(object sender, RoutedEventArgs e) => new DoctorSearchModal(this).Show();
        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();
        private void Settings_Click(object sender, RoutedEventArgs e) => new SettingsModal().Show();
        private async void Demo_Click(object sender, RoutedEventArgs e)
        {
            Brush colour = SearchButton.Background;
            await Task.Delay(300);
            SearchButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            SearchButton.Background = Brushes.White;
            await Task.Delay(300);
            SearchButton.Background = colour;
            await Task.Delay(300);
            SearchButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            SearchButton.Background = Brushes.White;
            await Task.Delay(300);
            SearchButton.Background = colour;
            var s = new DoctorSearchModal();
            s.Show();
            await Task.Delay(1000);
            s.Close();

            await Task.Delay(300);
            CreateButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            CreateButton.Background = Brushes.White;
            await Task.Delay(300);
            CreateButton.Background = colour;
            await Task.Delay(300);
            CreateButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            CreateButton.Background = Brushes.White;
            await Task.Delay(300);
            CreateButton.Background = colour;
            var ss = new SecretaryCreateModal();
            ss.Show();
            await Task.Delay(1000);
            ss.Close();

            await Task.Delay(300);
            GenerateReportButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            GenerateReportButton.Background = Brushes.White;
            await Task.Delay(300);
            GenerateReportButton.Background = colour;

            await Task.Delay(300);
            GenerateReportButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            GenerateReportButton.Background = Brushes.White;
            await Task.Delay(300);
            GenerateReportButton.Background = colour;
            var sss = new SecretaryGenerateReport();
            sss.Show();
            await Task.Delay(1000);
            sss.Close();

            var col = nextAppointment.Background;
            await Task.Delay(300);
            nextAppointment.Background = Brushes.Transparent;
            await Task.Delay(300);
            nextAppointment.Background = Brushes.White;
            await Task.Delay(300);
            nextAppointment.Background = col;
            await Task.Delay(300);
            nextAppointment.Background = Brushes.Transparent;
            await Task.Delay(300);
            nextAppointment.Background = Brushes.White;
            await Task.Delay(300);
            nextAppointment.Background = col;
            await Task.Delay(1000);

            await Task.Delay(300);
            SettingsButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            SettingsButton.Background = Brushes.White;
            await Task.Delay(300);
            SettingsButton.Background = colour;

            await Task.Delay(300);
            SettingsButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            SettingsButton.Background = Brushes.White;
            await Task.Delay(300);
            SettingsButton.Background = colour;
            var ssss = new SettingsModal();
            ssss.Show();
            await Task.Delay(1000);
            ssss.Close();


            await Task.Delay(300);
            FeedbackButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            FeedbackButton.Background = Brushes.White;
            await Task.Delay(300);
            FeedbackButton.Background = colour;

            await Task.Delay(300);
            FeedbackButton.Background = Brushes.Transparent;
            await Task.Delay(300);
            FeedbackButton.Background = Brushes.White;
            await Task.Delay(300);
            FeedbackButton.Background = colour;
            var sssss = new FeedbackModal();
            sssss.Show();
            await Task.Delay(1000);
            sssss.Close();
            await Task.Delay(1000);

        }
        private void Button_Click(object sender, RoutedEventArgs e) => new SecretaryCreateModal().Show();
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e) => new SecretaryGenerateReport().Show();

        private void AppointmentList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        }

        private void CurrentDoctor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorGrid.Visibility = Visibility.Hidden;
            CurrentDoctor.Content = "";
            app.SelectedDoctor = null;
            CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();

        }


        //private void SelectedDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //    => CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddDays(-1);
            SelectedDatePick.SelectedDate = CurrentDate;
            CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource);
            view.Filter = CombinedFilter;

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDate = CurrentDate.AddDays(1);
            SelectedDatePick.SelectedDate = CurrentDate;
            CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource).Refresh();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AppointmentList.ItemsSource);
            view.Filter = CombinedFilter;

        }
    }
}
