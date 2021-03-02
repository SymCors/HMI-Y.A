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
        bool fan1Clicked, fan2Clicked, winderButtonClicked, unwinderButtonClicked, insideButtonClicked;
        UInt16 workingmodeInt = 0;

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

        private void WinderButton_Click(object sender, RoutedEventArgs e)
        {
            winderButtonClicked = !winderButtonClicked;
            if (winderButtonClicked)
            {
                WinderButton.Background = Brushes.Orange;
                WinderButton.Content = "Açık";
            }
            else
            {
                WinderButton.Background = Brushes.White;
                WinderButton.Content = "Kapalı";
            }
        }

        private void Fan1_Click(object sender, RoutedEventArgs e)
        {
            fan1Clicked = !fan1Clicked;
            if (fan1Clicked)
                Fan1.Background = Brushes.Orange;
            else
                Fan1.Background = Brushes.White;
        }

        private void unwinderDiameter_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(unwinderDiameter, 0, 60, 6, "50", "5325");
        }

        private void winderDiameter_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(winderDiameter, -231, 60, 6, "642", "6342");
        }

        private void PressureReset_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void workingMode_TouchDown(object sender, TouchEventArgs e)
        {
            workingmodeInt++;
            if (workingmodeInt > 2)
            {
                workingmodeInt = 0;
            }
            switch (workingmodeInt)
            {
                case 0:
                    workingMode.Background = Brushes.White;
                    workingMode.Content = "4+0 ÇALIŞMA MODU AKTİF";
                    break;
                case 1:
                    workingMode.Background = Brushes.Orange;
                    workingMode.Content = "2+2 ÇALIŞMA MODU AKTİF";
                    break;
                case 2:
                    workingMode.Background = Brushes.LightGreen;
                    workingMode.Content = "3+1 ÇALIŞMA MODU AKTİF";
                    break;
            }
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

        private void UnwinderButton_Click(object sender, RoutedEventArgs e)
        {
            unwinderButtonClicked = !unwinderButtonClicked;
            if (unwinderButtonClicked)
            {
                UnwinderButton.Background = Brushes.Orange;
                UnwinderButton.Content = "Açık";
            }
            else
            {
                UnwinderButton.Background = Brushes.White;
                UnwinderButton.Content = "Kapalı";
            }
        }

        private void Fan2_Click(object sender, RoutedEventArgs e)
        {
            fan2Clicked = !fan2Clicked;
            if (fan2Clicked)
                Fan2.Background = Brushes.Orange;
            else
                Fan2.Background = Brushes.White;
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
