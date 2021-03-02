using KeyPad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : UserControl
    {
        ContentControl content;
        bool fan1Clicked, fan2Clicked, insideButtonClicked;
        bool workingmode;

        public Image(ContentControl contentControl)
        {
            InitializeComponent();
            content = contentControl;
        }

        private void fan1_orange_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(fan1_orange, 0, 40, 6, "123", "6432");
        }

        private void fan2_orange_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(fan2_orange, 0, 40, 6, "562", "4564");
        }

        private void Fan1_Click(object sender, RoutedEventArgs e)
        {
            fan1Clicked = !fan1Clicked;
            if (fan1Clicked)
                Fan1.Background = Brushes.Orange;
            else
                Fan1.Background = Brushes.White;
        }

        private void Fan2_Click(object sender, RoutedEventArgs e)
        {
            fan2Clicked = !fan2Clicked;
            if (fan2Clicked)
                Fan2.Background = Brushes.Orange;
            else
                Fan2.Background = Brushes.White;
        }

        private void WorkingMode_TouchDown(object sender, TouchEventArgs e)
        {
            switch (workingmode)
            {
                case true:
                    workingMode.Background = Brushes.White;
                    workingMode.Content = "4+0 ÇALIŞMA MODU AKTİF";
                    break;
                case false:
                    workingMode.Background = Brushes.Orange;
                    workingMode.Content = "2+2 ÇALIŞMA MODU AKTİF";
                    break;
            }
            workingmode = !workingmode;
            Console.WriteLine(workingmode.ToString());
        }

        private void LeftUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftUpDiameter_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void LeftDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftDown_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void RightUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RightUp_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void InsideButton_Click(object sender, RoutedEventArgs e)
        {
            insideButtonClicked = !insideButtonClicked;
            if (insideButtonClicked)
            {
                InsideButton.Background = Brushes.Green;
                InsideButton.Content = "Dışarı -->";
            }
            else
            {
                InsideButton.Background = Brushes.Red;
                InsideButton.Content = "<-- İçeri";
            }
        }

        private void openKeypad(TextBox textBox, int x, int y, int text_max_length, string min, string max)
        {
            Point relativePoint = textBox.TransformToAncestor(Window.GetWindow(this))
                             .Transform(new Point(0, 0));
            Keypad keypad = new Keypad(Window.GetWindow(this), text_max_length, min, max, textBox.Text);
            keypad.Top = relativePoint.Y + y;
            keypad.Left = relativePoint.X + x;
            if (keypad.ShowDialog() == true)
                textBox.Text = keypad.Result;
        }
    }
}
