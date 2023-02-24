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
using System.Windows.Shapes;
using Project.Views.Model;

namespace Project.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Email { get; set; }
        App app;
        public LoginWindow()
        {
            app = System.Windows.Application.Current as App;
            InitializeComponent();


            //for validation to work
            this.DataContext = this;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(Email != "" && PasswordTextBox.Password != "")
            {
            Tuple<UserDTO, string> tuple = app.AuthenticationController.Login(Email, PasswordTextBox.Password);
            if (tuple == null)
            {
                System.Windows.Forms.MessageBox.Show("Neuspešno prijavljivanje", "Neuspešno prijavljivanje", MessageBoxButtons.OK);
                return;
            } 
            
            app.currentUser = tuple.Item1;
            string role = tuple.Item2;
            switch (role)
            {
                case "Director": new Director.HomeWindow().Show(); break;
                case "Secretary": new Secretary.SecretaryHomeWindow().Show(); break;
                case "Doctor": new Doctor.HomeWindow(Email).Show(); break;
                case "Patient": new Patient.HomeWindow(Email).Show(); break;
                default: System.Windows.Forms.MessageBox.Show("Neuspešno prijavljivanje", "Neuspešno prijavljivanje", MessageBoxButtons.OK); break;
            }

            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var s = new Patient.RegisterPatient();
            s.Show();
        }
    }
}
