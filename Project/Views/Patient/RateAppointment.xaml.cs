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
using Project.Views.Model;

namespace Project.Views.Patient
{
    /// <summary>
    /// Interaction logic for RateAppointment.xaml
    /// </summary>
    public partial class RateAppointment : Window
    {
        public MedicalAppointmentDTO ReviewAppointment { get; set; }
        private App app;

        public RateAppointment(MedicalAppointmentDTO appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            ReviewAppointment = appointment;
            app = Application.Current as App;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            app.ReviewController.Save(new ReviewDTO(int.Parse(Rating.Text), Desc.Text, ReviewAppointment.Doctors.First()));
            Close();
        }
    }
}
