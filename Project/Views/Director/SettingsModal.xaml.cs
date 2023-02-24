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
    /// Interaction logic for SettingsModal.xaml
    /// </summary>
    public partial class SettingsModal : Window
    {
        public SettingsModal()
        {
            InitializeComponent();
        }


        private void CancelSettingsChange(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveSettingsChange(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            string language = LanguageBox.SelectedValue.ToString();
            string theme = ThemeBox.SelectedValue.ToString();
            if (theme.Equals("Light(standard)"))
            {
                app.ChangeTheme(new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignExtensions;component/Themes/MaterialDesignLightTheme.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/Generic.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignExtensions;component/Themes/Generic.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            if (theme.Equals("Dark"))
            {
                app.ChangeTheme(new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignExtensions;component/Themes/MaterialDesignDarkTheme.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/Generic.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml", UriKind.RelativeOrAbsolute));
                app.AddTheme(new Uri(@"pack://application:,,,/MaterialDesignExtensions;component/Themes/Generic.xaml", UriKind.RelativeOrAbsolute));
            }

            if (language.Equals("Srpski"))
            {
                app.ChangeLanguage(new Uri(@"Resources/Dictionaries/StringsSRB.xaml", UriKind.RelativeOrAbsolute));
            }
            else
                if (language.Equals("English"))
            {
                app.ChangeLanguage(new Uri(@"Resources/Dictionaries/StringsENG.xaml", UriKind.RelativeOrAbsolute));
            }
            else
                MessageBox.Show(language);
            
            
            this.Close();
        }
    }
}
