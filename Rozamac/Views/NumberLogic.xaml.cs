using KeyPad;
using Rozamac.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for NumberLogic.xaml
    /// </summary>
    public partial class NumberLogic : UserControl
    {
        ContentControl content;
        bool r1clicked, r2clicked, r3clicked, r4clicked, fan1clicked, fan2clicked, winderButtonClicked, unwinderButtonClicked;
        bool winderCenter, unwinderCenter, winderDirectionClicked, winderManualClicked, unwinderManualClicked;
        int value = 0;
        int value2 = 0;
        MainController mainController;

        public NumberLogic(ContentControl contentControl, MainController main)
        {
            InitializeComponent();
            content = contentControl;
            mainController = main;
        }

        private void color1_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(color1, 0, 40, 6, "213", "5324");
        }

        private void color2_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(color2, 0, 40, 6, "213", "5324");
        }

        private void color3_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(color3, 0, 40, 6, "213", "5324");
        }

        private void color4_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(color4, 0, 40, 6, "213", "5324");
        }

        private void pressure1_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(pressure1, 0, 40, 6, "213", "5324");
        }

        private void pressure2_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(pressure2, 0, 40, 6, "213", "5324");
        }

        private void pressureNumber1_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(pressureNumber1, 0, 40, 6, "213", "5324");
        }

        private void pressureNumber2_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(pressureNumber2, 0, 40, 6, "213", "5324");
        }

        private void fan1_orange_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(fan1_orange, 0, 40, 6, "213", "5324");
        }

        private void fan1_blue_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(fan1_blue, 0, 40, 6, "213", "5324");
        }

        private void fan2_orange_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(fan2_orange, 0, 40, 6, "213", "5324");
        }
        private void fan2_blue_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(fan2_blue, 0, 40, 6, "213", "5324");
        }

        private void center_sensitivity_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(center_sensitivity, 0, 30, 2, "0", "100");
        }

        private void center_sensitivity_unwinder_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(center_sensitivity_unwinder, 0, -455, 2, "0", "100");
        }

        private void winder_orange_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(winder_orange, -135, 40, 6, "213", "5324");
        }

        private void winder_blue_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(winder_blue, -135, 40, 6, "213", "5324");
        }

        private void unwinder_orange_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(unwinder_orange, -135, -470, 6, "213", "5324");
        }

        private void unwinder_blue_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(unwinder_blue, -135, -470, 6, "213", "5324");
        }

        private void PressureLengthReset_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void PressureAmountReset_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void R1_TouchDown(object sender, TouchEventArgs e)
        {
            r1clicked = !r1clicked;
            if (r1clicked)
                R1.Background = Brushes.Orange;
            else
                R1.Background = Brushes.White;
        }

        private void R2_TouchDown(object sender, TouchEventArgs e)
        {
            r2clicked = !r2clicked;
            if (r2clicked)
                R2.Background = Brushes.Orange;
            else
                R2.Background = Brushes.White;
        }

        private void R3_TouchDown(object sender, TouchEventArgs e)
        {
            r3clicked = !r3clicked;
            if (r3clicked)
                R3.Background = Brushes.Orange;
            else
                R3.Background = Brushes.White;
        }

        private void R4_TouchDown(object sender, TouchEventArgs e)
        {
            r4clicked = !r4clicked;
            if (r4clicked)
                R4.Background = Brushes.Orange;
            else
                R4.Background = Brushes.White;
        }

        private void Fan1_TouchDown(object sender, TouchEventArgs e)
        {
            fan1clicked = !fan1clicked;
            if (fan1clicked)
                Fan1.Background = Brushes.Orange;
            else
                Fan1.Background = Brushes.White;
        }

        private void Fan2_TouchDown(object sender, TouchEventArgs e)
        {
            fan2clicked = !fan2clicked;
            if (fan2clicked)
                Fan2.Background = Brushes.Orange;
            else
                Fan2.Background = Brushes.White;
        }
        private void center_sensitivity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int percentage = Convert.ToInt16(center_sensitivity.Text);
                float width = percentage * 4.49f;

                if (width > 449)
                {
                    width = 449;
                }
                winderProgressRect1.Width = width;
                winderProgressRect2.Width = width;
            }
            catch { }
        }

        private void center_sensitivity_unwinder_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int percentage = Convert.ToInt16(center_sensitivity_unwinder.Text);
                float width = percentage * 4.49f;

                if (width > 449)
                {
                    width = 449;
                }
                unwinderProgressRect1.Width = width;
                unwinderProgressRect2.Width = width;
            }
            catch { }
        }

        private void WinderDirection_TouchDown(object sender, TouchEventArgs e)
        {
            winderDirectionClicked = !winderDirectionClicked;
            if (winderDirectionClicked)
                WinderDirection.Background = Brushes.Green;
            else
                WinderDirection.Background = Brushes.Red;
        }

        private void WinderRight_Click(object sender, RoutedEventArgs e)
        {
            winderRightProgressBar.Value = value++;
        }

        private void WinderLeft_Click(object sender, RoutedEventArgs e)
        {
            winderLeftProgressBar.Value = value++;
        }

        private void UnwinderRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UnwinderLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WinderManual_TouchDown(object sender, TouchEventArgs e)
        {
            winderManualClicked = !winderManualClicked;
            if (winderManualClicked)
                WinderManual.Background = Brushes.Orange;
            else
                WinderManual.Background = Brushes.Black;
        }

        private void UnwinderManual_TouchDown(object sender, TouchEventArgs e)
        {
            unwinderManualClicked = !unwinderManualClicked;
            if (unwinderManualClicked)
                UnwinderManual.Background = Brushes.Orange;
            else
                UnwinderManual.Background = Brushes.Black;
        }

        private void WinderCenter_TouchDown(object sender, TouchEventArgs e)
        {
            winderCenter = !winderCenter;
            if (winderCenter)
                WinderCenter.Background = Brushes.Orange;
            else
                WinderCenter.Background = Brushes.Blue;
        }

        private void UnwinderCenter_TouchDown(object sender, TouchEventArgs e)
        {
            unwinderCenter = !unwinderCenter;
            if (unwinderCenter)
                UnwinderCenter.Background = Brushes.Orange;
            else
                UnwinderCenter.Background = Brushes.Blue;
        }

        private void UnwinderButton_TouchDown(object sender, TouchEventArgs e)
        {
            unwinderButtonClicked = !unwinderButtonClicked;
            if (unwinderButtonClicked)
                UnwinderButton.Background = Brushes.Orange;
            else
                UnwinderButton.Background = Brushes.Black;
        }

        private void WinderButton_TouchDown(object sender, TouchEventArgs e)
        {
            winderButtonClicked = !winderButtonClicked;
            if (winderButtonClicked)
                WinderButton.Background = Brushes.Orange;
            else
                WinderButton.Background = Brushes.Black;
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
