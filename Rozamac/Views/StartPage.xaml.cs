using Rozamac.Controllers;
using Rozamac.Events;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rozamac.Views
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl
    {
        ContentControl content;
        MainController main;

        public IList<object> list;

        public StartPage(ContentControl contentControl, MainController mainController)
        {
            InitializeComponent();
            content = contentControl;
            main = mainController;

            StartEvent.event1 -= StartEvent_event1;
            StartEvent.event1 += StartEvent_event1;

            if (Properties.Settings.Default.Admin) { ProgramSettings.Visibility = Visibility.Visible; }
            else { ProgramSettings.Visibility = Visibility.Collapsed; }
        }

        private void StartEvent_event1(object sender, StartEvent e)
        {
            list = e.list;

            Dispatcher.Invoke(() =>
            {
                try
                {
                    gMakinaDurumWord.Content = list[0].ToString();
                }
                catch { }
            });
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new MainTemplate(content, "", main);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            content.Content = new MainTemplate(content, "", main);
        }

        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            UserSelectionPage userSelectionPage = new UserSelectionPage(content, main);
            userSelectionPage.ShowDialog();
        }

        private void Alarms_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new MainTemplate(content, "Alarms", main);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SignedIn)
            {
                content.Content = new MainTemplate(content, "Settings", main);
            }
        }

        private void Turkish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProgramSettings_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new MainTemplate(content, "ProgramSettings", main);
        }
    }
}
