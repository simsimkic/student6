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
    /// Interaction logic for SettingsModal.xaml
    /// </summary>
    public partial class SettingsModal : Window
    {
        App app;
        public SettingsModal()
        {
            InitializeComponent();
            app = Application.Current as App;
            SecretaryDTO user = app.secretaries[0];
            Profile_FirstName.Text = user.FirstName;
            Profile_LastName.Text = user.LastName;
            Profile_DateOfBirth.SelectedDate = user.DateOfBirth;
            Profile_Email.Text = user.Email;
            Profile_TelephoneNumber.Text = user.TelephoneNumber;


            
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = true;
            Profile_LastName.IsEnabled = true;
            Profile_Email.IsEnabled = true;
            Profile_TelephoneNumber.IsEnabled = true;
            Profile_DateOfBirth.IsEnabled = true;
            Obustavi.Visibility = Visibility.Visible;
            Izmeni.Visibility = Visibility.Hidden;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Profile_FirstName.IsEnabled = false;
            Profile_LastName.IsEnabled = false;
            Profile_Email.IsEnabled = false;
            Profile_DateOfBirth.IsEnabled = false;
            Profile_TelephoneNumber.IsEnabled = false;
            Obustavi.Visibility = Visibility.Hidden;
            Izmeni.Visibility = Visibility.Visible;

        }
    }
}
