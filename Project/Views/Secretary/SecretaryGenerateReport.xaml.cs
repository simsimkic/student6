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
using System.Windows.Shapes;

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryGenerateReport.xaml
    /// </summary>
    public partial class SecretaryGenerateReport : Window
    {
        App app;
        public SecretaryGenerateReport()
        {
            InitializeComponent();
            app = Application.Current as App;
            Beginning.SelectedDate = DateTime.Now.AddDays(-7);
            End.SelectedDate = DateTime.Now;
        }

        private void GenerateReport_Button_Click(object sender, RoutedEventArgs e)
        {
            string start = Beginning.Text as string;
            string end = End.Text as string;
            DateTime from = Convert.ToDateTime(start);
            DateTime to = Convert.ToDateTime(end);
            app.SecretaryAppointmentReportGenerator.Generate(new TimeInterval(from,to));
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
            => this.Close();
    }
}
