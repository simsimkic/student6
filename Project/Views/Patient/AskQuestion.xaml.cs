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
    /// Interaction logic for AskQuestion.xaml
    /// </summary>
    public partial class AskQuestion : Window
    {
        private App app;
        public PatientDTO CurrentPatient;

        public AskQuestion(PatientDTO patient)
        {
            InitializeComponent();
            app = Application.Current as App;
            CurrentPatient = patient;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DateTime sad = DateTime.Now;
            
            app.QuestionController.Save(new QuestionDTO(Question.Text, null, CurrentPatient, null, DateTime.Now ));
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
