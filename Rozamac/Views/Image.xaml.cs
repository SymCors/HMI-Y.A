using KeyPad;
using Rozamac.Controllers;
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
        MainController mainController;

        bool gSarici1Enabled, gSarici2Enabled;

        public Image(ContentControl contentControl, MainController main)
        {
            InitializeComponent();

            HomePageEvent.event1 -= HomePageEvent_event1;
            HomePageEvent.event1 += HomePageEvent_event1;

            content = contentControl;
            mainController = main;
        }

        private void HomePageEvent_event1(object sender, HomePageEvent e)
        {
            list = e.list;
            Dispatcher.Invoke(() =>
            {
                try
                {
                    gActualBaskiAdet.Text = String.Format("{0:0.0}", Convert.ToDouble(list[0]));
                    gAdetSet.Text = String.Format("{0:0.0}", Convert.ToDouble(list[1]));
                    gActualMetraj.Text = String.Format("{0:0.0}", Convert.ToDouble(list[2]));
                    gMetrajSet.Text = String.Format("{0:0.0}", Convert.ToDouble(list[3]));
                    gTunelIsiSet.Text = String.Format("{0:0.0}", Convert.ToDouble(list[4]));
                    gTunelIsiActual.Text = String.Format("{0:0.0}", Convert.ToDouble(list[5]));
                    gRenkIsiSet.Text = String.Format("{0:0.0}", Convert.ToDouble(list[6]));
                    gRenkIsiActual.Text = String.Format("{0:0.0}", Convert.ToDouble(list[7]));

                    gSarici1SetKg.Text = String.Format("{0:0.0}", Convert.ToDouble(list[8]));
                    gSarici1ActKg.Text = String.Format("{0:0.0}", Convert.ToDouble(list[9]));
                    gSarici2SetKg.Text = String.Format("{0:0.0}", Convert.ToDouble(list[10]));
                    gSarici2ActKg.Text = String.Format("{0:0.0}", Convert.ToDouble(list[11]));
                    gCozguSetKg.Text = String.Format("{0:0.0}", Convert.ToDouble(list[12]));
                    gCozguActKg.Text = String.Format("{0:0.0}", Convert.ToDouble(list[13]));
                    gCapSet.Text = String.Format("{0:0.0}", Convert.ToDouble(list[14]));
                    gCozguActCap.Text = String.Format("{0:0.0}", Convert.ToDouble(list[15]));

                    SAxis1.Text = String.Format("{0:0.0}", Convert.ToDouble(list[16]));
                    SAxis2.Text = String.Format("{0:0.0}", Convert.ToDouble(list[17]));
                    SAxis3.Text = String.Format("{0:0.0}", Convert.ToDouble(list[18]));
                    SAxis4.Text = String.Format("{0:0.0}", Convert.ToDouble(list[19]));
                }
                catch { }
            });
        }

        private void gAdetSet_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gAdetSet, 0, 40, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gAdetSet(Convert.ToDouble(keypad.Result.ToString()));
            }
        }

        private void gMetrajSet_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gMetrajSet, 0, 40, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gMetrajSet(Convert.ToDouble(keypad.Result.ToString()));
            }
        }

        private void gMetrajReset_TouchDown(object sender, TouchEventArgs e)
        {
            mainController.Write_gMetrajReset(true);
        }

        private void gFanStart_TouchDown(object sender, TouchEventArgs e)
        {
            fanClicked = !fanClicked;
            if (fanClicked)
            {
                gTunelIsi.Background = Brushes.Orange;
                gRenkIsi.Background = Brushes.Orange;
                mainController.Write_gFanStart(true);
            }
            else
            {
                gTunelIsi.Background = Brushes.White;
                gRenkIsi.Background = Brushes.White;
                mainController.Write_gFanStart(false);
            }
        }

        private void gTunelIsiSet_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gTunelIsiSet, 0, 40, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gTunelIsiSet(Convert.ToDouble(keypad.Result.ToString()));
            }
        }

        private void gRenkIsiSet_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gRenkIsiSet, 0, 40, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gRenkIsiSet(Convert.ToDouble(keypad.Result.ToString()));
            }
        }

        private void gSarici1SetKg_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gSarici1SetKg, 0, 80, 6, "0", "100");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gSarici1SetKg(Convert.ToDouble(keypad.Result));
            }
        }

        private void gSarici1Enable_TouchDown(object sender, TouchEventArgs e)
        {
            gSarici1Enabled = !gSarici1Enabled;
            mainController.Write_gSarici1Enable(gSarici1Enabled);
        }

        private void gSarici2SetKg_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gSarici2SetKg, 135, -300, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gSarici2SetKg(Convert.ToInt32(keypad.Result.ToString()));
            }
        }

        private void gSarici2Enable_TouchDown(object sender, TouchEventArgs e)
        {
            gSarici2Enabled = !gSarici2Enabled;
            mainController.Write_gSarici2Enable(gSarici2Enabled);
        }

        private void gCozguSetKg_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gCozguSetKg, 135, -200, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gCozguSetKg(Convert.ToInt32(keypad.Result.ToString()));
            }
        }
        private void gCapSet_TouchDown(object sender, TouchEventArgs e)
        {
            Keypad keypad = openKeypad(gCapSet, 135, -300, 6, "123", "6432");
            if (keypad.ShowDialog() == true)
            {
                mainController.Write_gCapSet(Convert.ToDouble(keypad.Result.ToString()));
            }
        }

        private void gSarici1Yon_TouchDown(object sender, TouchEventArgs e)
        {
            insideButtonClicked = !insideButtonClicked;
            if (insideButtonClicked)
            {
                gSarici1Yon.Background = Brushes.Green;
                gSarici1Yon.Content = "Dışarı -->";
                mainController.Write_gSarici1Yon(true);
            }
            else
            {
                gSarici1Yon.Background = Brushes.Red;
                gSarici1Yon.Content = "<-- İçeri";
                mainController.Write_gSarici1Yon(false);
            }
        }

        private void gMakinaCalismaModu_TouchDown(object sender, TouchEventArgs e)
        {
            switch (workingmode)
            {
                case true:
                    double value = 2f;
                    gMakinaCalismaModu.Background = Brushes.White;
                    gMakinaCalismaModu.Content = "4+0 ÇALIŞMA MODU AKTİF";
                    mainController.Write_gMakinaCalismaModu(value);
                    break;
                case false:
                    double values = 1f;
                    gMakinaCalismaModu.Background = Brushes.Orange;
                    gMakinaCalismaModu.Content = "2+2 ÇALIŞMA MODU AKTİF";
                    mainController.Write_gMakinaCalismaModu(values);
                    break;
            }
            workingmode = !workingmode;
        }

        private Keypad openKeypad(TextBox textBox, int x, int y, int text_max_length, string min, string max)
        {
            Point relativePoint = textBox.TransformToAncestor(Window.GetWindow(this))
                             .Transform(new Point(0, 0));
            Keypad keypad = new Keypad(Window.GetWindow(this), text_max_length, min, max, textBox.Text);
            keypad.Top = relativePoint.Y + y;
            keypad.Left = relativePoint.X + x;
            return keypad;
        }
    }
}
