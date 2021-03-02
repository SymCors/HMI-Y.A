using Rozamac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        ContentControl content;
        string currentSelected = "PasswordBox";

        public Login(ContentControl contentControl)
        {
            InitializeComponent();
            content = contentControl;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new StartPage(content);
        }

        private void PasswordChecked(object sender, RoutedEventArgs e)
        {
            Password.Visibility = Visibility.Collapsed;
            PasswordHidden.Visibility = Visibility.Visible;

            PasswordHidden.Text = Password.Password;
            PasswordHidden.CaretIndex = PasswordHidden.Text.Length;
            PasswordHidden.Focus();
            currentSelected = "TextBox";
        }

        private void PasswordUncheck(object sender, RoutedEventArgs e)
        {
            Password.Visibility = Visibility.Visible;
            PasswordHidden.Visibility = Visibility.Collapsed;

            Password.Password = PasswordHidden.Text;

            Password.GetType().GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(Password, new object[] { Password.Password.Length, 0 });
            Password.Focus();
            currentSelected = "PasswordBox";
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (currentSelected == "TextBox")
            {
                Password.Password = PasswordHidden.Text;
            }
            if (username.Text.ToLower() == "unity" && Password.Password == "1453")
            {
                Properties.Settings.Default.SignedIn = true;
                Properties.Settings.Default.Save();
                content.Content = new StartPage(content);
            }
            else if (username.Text.ToLower() == "admin" && Password.Password == "unity1453")
            {
                Properties.Settings.Default.Admin = true;
                Properties.Settings.Default.Save();
                content.Content = new StartPage(content);
            }
            incorrectLabel.Visibility = Visibility.Visible;
        }

        private void username_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboards.showKeyboard();
        }

        private void Password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboards.showKeyboard();
        }
    }
}
