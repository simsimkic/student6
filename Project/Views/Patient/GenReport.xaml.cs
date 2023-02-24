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

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for GenReport.xaml
    /// </summary>
    public partial class GenReport : Window
    {
        private Project.App app;
        public GenReport()
        {
            InitializeComponent();
            app = System.Windows.Application.Current as App;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            string start = DateFrom.Text as string;
            string end = DateTo.Text as string;
            DateTime from = Convert.ToDateTime(start);
            DateTime to = Convert.ToDateTime(end);
            app.PatientAppointmentReportGenerator.Generate(new Project.Model.TimeInterval(from,to));
        }
    }
}
