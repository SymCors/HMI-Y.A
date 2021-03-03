using Rozamac.Controllers;
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

namespace Rozamac.Views
{
    /// <summary>
    /// Interaction logic for UserSelectionPage.xaml
    /// </summary>
    public partial class UserSelectionPage : Window
    {
        ContentControl content;
        MainController mainController;

        public UserSelectionPage(ContentControl contentControl, MainController main)
        {
            InitializeComponent();
            content = contentControl;
            mainController = main;
        }

        private void ChooseUser_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new Login(content, mainController);
            Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Admin = false;
            Properties.Settings.Default.SignedIn = false;
            Properties.Settings.Default.Save();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
