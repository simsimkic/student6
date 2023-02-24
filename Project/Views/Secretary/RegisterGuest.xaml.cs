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
    /// Interaction logic for RegisterPatient.xaml
    /// </summary>
    public partial class RegisterGuest : Window
    {
        App app;
        public GuestDTO RegisteringPatient { get; set; }
        public RegisterGuest()
        {
            InitializeComponent();
            this.DataContext = this;
            app = Application.Current as App;
            RegisteringPatient = new PatientDTO();
            RegisteringPatient.DateOfBirth = DateTime.Now;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            app.GuestController.Save(RegisteringPatient);
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
