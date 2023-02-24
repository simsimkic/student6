using Project.Model;
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

namespace Project.Views.Tabs.AppointmentTabs
{
    /// <summary>
    /// Interaction logic for AppointmentsDay.xaml
    /// </summary>
    public partial class AppointmentsDay : UserControl
    {
        public List<MedicalAppointment> appointments;
        public AppointmentsDay()
        {
            appointments = new List<MedicalAppointment>();
            InitializeComponent();
            DataContext = appointments;


        }

        private void Calendar_AddAppointment(object sender, RoutedEventArgs e)
        {
            //MedicalAppointment appointment = new MedicalAppointment
            //{
            //    Beginning = new DateTime(2008, 10, 22, 16, 00, 00),
            //    End = new DateTime(2008, 10, 22, 17, 00, 00)
            //};


        }
    }
}
