using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project.Views.Model;
using System.Windows.Controls;

namespace Project.Views.Templates
{
    partial class Details : ResourceDictionary
    {
        private void Profile_Click(object sender, RoutedEventArgs e)
            => new ProfileModal((MedicalAppointmentDTO)(sender as Button).DataContext).Show();
    }
}
