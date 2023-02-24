using Project.Model;
using Project.Views.Model;
using Project.Views.Secretary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Views.Tabs
{
    public partial class SecretaryQuestions : UserControl
    {
        public QuestionDTO CurrentQuestion;
        App app;

        public SecretaryQuestions()
        {
            app = Application.Current as App;
            InitializeComponent();

            QuestionsList.ItemsSource = app.QuestionController.GetAll();
            SelectedQuestion.Visibility = Visibility.Hidden;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(QuestionsList.ItemsSource);
            view.Filter = CombinedFilter;

        }
        private bool CombinedFilter(object item)
            => QuestionFilter(item) && AnsweredFilter( item);
        private bool QuestionFilter(object item)
          => (String.IsNullOrEmpty(Question_TextBox.Text) ||
            (item as QuestionDTO).QuestionText.IndexOf(Question_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        private bool AnsweredFilter(object item)
          => (Answered_CheckBox.IsChecked.Value) ||
            (item as QuestionDTO).AnswerText.Equals("");
        private void Question_TextBox_TextChanged(object sender, TextChangedEventArgs e)
            => CollectionViewSource.GetDefaultView(QuestionsList.ItemsSource).Refresh();
        private void Answered_CheckBox_Click(object sender, RoutedEventArgs e)
            => CollectionViewSource.GetDefaultView(QuestionsList.ItemsSource).Refresh();

        private void Feedback_Click(object sender, RoutedEventArgs e) => new FeedbackModal().Show();
        private void Settings_Click(object sender, RoutedEventArgs e) => new SettingsModal().Show();
        private async void Demo_Click(object sender, RoutedEventArgs e)
        {

            Brush colour = Submit_Button.Background;
            await Task.Delay(1000);
            Question_TextBox.Text = "Pitanje";
            await Task.Delay(1000);
            Answered_CheckBox.IsChecked = true;
            CollectionViewSource.GetDefaultView(QuestionsList.ItemsSource).Refresh();
            await Task.Delay(1000);
            Answered_CheckBox.IsChecked = false;
            CollectionViewSource.GetDefaultView(QuestionsList.ItemsSource).Refresh();
            await Task.Delay(1000);
            CurrentQuestion = app.QuestionController.GetAll().First();
            Question.Text = CurrentQuestion.QuestionText;
            SelectedQuestion.Visibility = Visibility.Visible;
            await Task.Delay(1000);
            Answer.Text = "Nekakav odgovor na odabrano pitanje";

            await Task.Delay(200);
            Submit_Button.Background = Brushes.White;
            await Task.Delay(200);
            Submit_Button.Background = Brushes.Transparent;
            await Task.Delay(200);
            Submit_Button.Background = colour;
            await Task.Delay(1000);
            

            await Task.Delay(200);
            Submit_Button.Background = Brushes.White;
            await Task.Delay(200);
            Submit_Button.Background = Brushes.Transparent;
            await Task.Delay(200);
            Submit_Button.Background = colour;
            await Task.Delay(1000);
            SelectedQuestion.Visibility = Visibility.Hidden;

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
            => new ProfileModal(CurrentQuestion.Patient).Show();

        private void QuestionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentQuestion = (QuestionDTO)QuestionsList.SelectedItem;
            SelectedQuestion.Visibility = Visibility.Visible;
            Question.Text = CurrentQuestion.QuestionText;
            Answer.Text = CurrentQuestion.AnswerText;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuestionDTO q = app.QuestionController.GetById(CurrentQuestion.Id);
            q.AnswerText = Answer.Text;
            app.QuestionController.Save(q);
        }
    }
}
