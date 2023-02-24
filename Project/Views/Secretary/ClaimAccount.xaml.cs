using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for ClaimAccount.xaml
    /// </summary>
    public partial class ClaimAccount : Window
    {
        App app;
        public string Email { get; set;  }
        public string Password { get; set;  }
        public GuestDTO Guest { get; set;  }
        public ClaimAccount(GuestDTO guest)
        {
            InitializeComponent();
            app = Application.Current as App;
            GuestDTO Guest = guest;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            app.PatientController.ClaimGuestAccount(Guest, Email, Password);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
