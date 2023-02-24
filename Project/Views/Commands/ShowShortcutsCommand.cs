using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.Views.Commands
{
    public class ShortcutsCommand : ICommand
    {
        public void Execute(object parameter)
        {
            string msg;

            if (parameter.Equals("Shortcuts"))
                new Shortcuts().Show();
            else if (parameter.Equals("Help"))
                new Shortcuts().Show();
            else if (parameter.Equals("Feedback"))
                new FeedbackModal().Show();
            else if (parameter.Equals("Settings"))
                new SettingsModal().Show();
            else if (parameter.Equals("CreateAppointment"))
               new SecretaryCreateModal().Show();
            else if (parameter.Equals("GenerateReport"))
               new SecretaryGenerateReport().Show();
            else if (parameter.Equals("SelectDoctor"))
               new DoctorSearchModal().Show();
            else
            {
                msg = parameter.ToString();
                MessageBox.Show(msg);
            }

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
