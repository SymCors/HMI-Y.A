using KeyPad;
using Rozamac.Events;
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
using System.Windows.Threading;

namespace Rozamac.Views
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : UserControl
    {
        public IList<object> list;
        ContentControl content;
        bool fanClicked, insideButtonClicked;
        bool workingmode;

        public Image(ContentControl contentControl)
        {
            InitializeComponent();

            HomePageEvent.event1 -= HomePageEvent_event1;
            HomePageEvent.event1 += HomePageEvent_event1;

            content = contentControl;
        }

        private void HomePageEvent_event1(object sender, HomePageEvent e)
        {
            list = e.list;
            Dispatcher.Invoke(() =>
            {
                try
                {
                    gActualBaskiAdet.Text = list[0].ToString();
                    gAdetSet.Text = list[1].ToString();
                    gActualMetraj.Text = list[2].ToString();
                    gMetrajSet.Text = list[3].ToString();
                    gTunelIsiSet.Text = list[4].ToString();
                    gTunelIsiActual.Text = list[5].ToString();
                    gRenkIsiSet.Text = list[6].ToString();
                    gRenkIsiActual.Text = list[7].ToString();

                    gSarici1SetKg.Text = list[8].ToString();
                    gSarici1ActKg.Text = list[9].ToString();
                    gSarici2SetKg.Text = list[10].ToString();
                    gSarici2ActKg.Text = list[11].ToString();
                    gCozguSetKg.Text = list[12].ToString();
                    gCozguActKg.Text = list[13].ToString();
                    gCapSet.Text = list[14].ToString();
                    gCozguActCap.Text = list[14].ToString();
                }
                catch { }
            });
        }

        private void gTunelIsiSet_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gTunelIsiSet, 0, 40, 6, "123", "6432");
        }

        private void gRenkIsiSet_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gRenkIsiSet, 0, 40, 6, "562", "4564");
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
        }

        private void gActualBaskiAdet_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gActualBaskiAdet, 0, 40, 6, "123", "6432");
        }

        private void gActualMetraj_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gActualMetraj, 0, 40, 6, "123", "6432");
        }

        private void gSarici1SetKg_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gSarici1SetKg, 0, 40, 6, "123", "6432");
        }

        private void gSarici2SetKg_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gSarici2SetKg, 0, 40, 6, "123", "6432");
        }

        private void gCozguSetKg_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gCozguSetKg, 0, 40, 6, "123", "6432");
        }

        private void gCapSet_TouchDown(object sender, TouchEventArgs e)
        {
            openKeypad(gCapSet, 0, 40, 6, "123", "6432");
        }

        private void gTunelIsi_TouchDown(object sender, TouchEventArgs e)
        {
            FanClicked();
        }

        private void gRenkIsi_TouchDown(object sender, TouchEventArgs e)
        {
            FanClicked();
        }

        private void InsideButton_TouchDown(object sender, TouchEventArgs e)
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

        private void FanClicked()
        {
            fanClicked = !fanClicked;
            if (fanClicked)
            {
                gTunelIsi.Background = Brushes.Orange;
                gRenkIsi.Background = Brushes.Orange;
            }
            else
            {
                gTunelIsi.Background = Brushes.White;
                gRenkIsi.Background = Brushes.White;
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
