using Project.Model;
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

namespace Project.Views.Tabs.AppointmentTabs
{
    /// <summary>
    /// Interaction logic for AppointmentsWeek.xaml
    /// </summary>
    public partial class AppointmentsWeek : UserControl
    {
        public DateTime SelectedDate;
        public DateTime StartOfTheWeek;
        public DateTime EndOfTheWeek;
        public DateTime CurrentDate;
        public AppointmentsWeek()
        {
            CurrentDate    = DateTime.Today;
            StartOfTheWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            EndOfTheWeek   = StartOfTheWeek.AddDays(6);
            SelectedDate   = CurrentDate;
            InitializeComponent();

            startWeekLabel.Content  = StartOfTheWeek.ToString("dddd, dd MMMM yyyy");
            endWeekLabel.Content    = EndOfTheWeek.ToString("dddd, dd MMMM yyyy");
        }
        private void Prev_Week_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Week_Click(object sender, RoutedEventArgs e)
        {

        }
        public List<MedicalAppointment> GetThisWeeksAppointements(List<MedicalAppointment> appointments)
        {
            //10080
            List<MedicalAppointment> list = new List<MedicalAppointment>();
            DateTime startOfTheWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime endOfTheWeek = startOfTheWeek.AddDays(7);

            TimeSpan weekInterval = startOfTheWeek - endOfTheWeek;

            foreach(MedicalAppointment item in appointments)
            {
                if(startOfTheWeek <= item.Beginning  && item.End <= endOfTheWeek)
                {
                    list.Add(item);
                }
            }

            return list;


        }
    }
}
