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

namespace Project.Views.Doctor
{
    /// <summary>
    /// Interaction logic for WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {
        public int step = 1;
        public string Email;

        public WizardWindow(string email)
        {
            InitializeComponent();

            Prethodna.Visibility = Visibility.Hidden;
            Step1.Visibility = Visibility.Visible;
            Step2.Visibility = Visibility.Hidden;
            Step3.Visibility = Visibility.Hidden;
            Step4.Visibility = Visibility.Hidden;
            Step5.Visibility = Visibility.Hidden;
            Progres.Value = 1 / 5;
            Email = email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var homeWindow = new HomeWindow(Email);
            homeWindow.Show();
            Close();
        }




        public void Prethodna_New(object sender, RoutedEventArgs e)
        {
            Progres.Value -= 25;
            Sledeca.Visibility = Visibility.Visible;
            
            switch (step)
            {
                case 2:
                    Prethodna.Visibility = Visibility.Hidden;
                    Step1.Visibility = Visibility.Visible;
                    Step2.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Step2.Visibility = Visibility.Visible;
                    Step3.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    Step3.Visibility = Visibility.Visible;
                    Step4.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    Step4.Visibility = Visibility.Visible;
                    Step5.Visibility = Visibility.Hidden;
                    break;
            }
            if (step > 1)
            {
                step--;
            }
        }

        private void Sledeca_Click(object sender, RoutedEventArgs e)
        {
            Progres.Value += 25;
            Prethodna.Visibility = Visibility.Visible;

            switch (step)
            {
                case 1:
                    Step1.Visibility = Visibility.Hidden;
                    Step2.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Step2.Visibility = Visibility.Hidden;
                    Step3.Visibility = Visibility.Visible;
                    break;
                case 3:
                    Step3.Visibility = Visibility.Hidden;
                    Step4.Visibility = Visibility.Visible;
                    break;
                case 4:
                    Step4.Visibility = Visibility.Hidden;
                    Step5.Visibility = Visibility.Visible;
                    Sledeca.Visibility = Visibility.Collapsed;
                    break;
            }
            if (step < 5)
            {
                step++;
            }
        }
    }
}
