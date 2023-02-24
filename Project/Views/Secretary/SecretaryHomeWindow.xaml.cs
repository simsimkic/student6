using Project.Model;
using Project.Views.Commands;
using Project.Views.Model;
using Project.Views.Tabs;
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

namespace Project.Views.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryHomeWindow.xaml
    /// </summary>
    public partial class SecretaryHomeWindow : Window
    {
        public MedicalAppointmentDTO SelectedAppointment;

        public SecretaryHomeWindow()
        {

            InitializeComponent();
        }

        private void ViewHelp()
            => new ShortcutsModal().Show();
        private void ShowShortcuts(object sender, RoutedEventArgs e) 
            => new ShortcutsModal().Show();
        private void CreateAppointment(object sender, RoutedEventArgs e) 
            => new SecretaryCreateModal().Show();
    }
}
