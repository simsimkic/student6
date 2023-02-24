using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project.Views.Templates
{
    partial class Appointment : ResourceDictionary
    {
        private void Term_Click(object sender, RoutedEventArgs e)
            => new AppointmentModal((MedicalAppointmentDTO)(sender as Button).DataContext).Show();


    }
}
