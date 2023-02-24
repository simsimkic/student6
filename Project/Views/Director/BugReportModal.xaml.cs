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

namespace Project.Views.Director
{
    /// <summary>
    /// Interaction logic for BugReportModal.xaml
    /// </summary>
    public partial class BugReportModal : Window
    {   
        public List<FeedbackDTO> Feedbacks { get; set; }
        public BugReportModal()
        {
            InitializeComponent();
            Feedbacks = new List<FeedbackDTO>();
            
        }

        private void ConfirmBugReport(object sender, RoutedEventArgs e)
        {
            String type = typeOfFeedback.SelectedValue.ToString();
            String desc = feedbackDescription.Text.ToString();

            FeedbackDTO newFeedback = new FeedbackDTO(type, desc);
            App app = App.Current as App;
            app.FeedbackController.Save(newFeedback);
            this.Close();
        }

        private void CancelBugReport(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
    }
}
