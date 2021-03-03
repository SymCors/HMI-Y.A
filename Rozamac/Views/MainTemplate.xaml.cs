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
using System.Windows.Threading;

namespace Rozamac.Views
{
    /// <summary>
    /// Interaction logic for MainTemplate.xaml
    /// </summary>
    public partial class MainTemplate : UserControl
    {
        public IList<object> list;
        ContentControl content;
        private string selected = "HomePage";
        private string selectedInner = "Image";
        MainController mainController;
        bool gOtomatikGitBool;


        private double _gMakinaActualHizValue, _gAnaHizSetMdkValue;

        public MainTemplate(ContentControl contentControl, string contentArea, MainController main)
        {
            InitializeComponent();

            MainEvent.event1 -= MainEvent_event1;
            MainEvent.event1 += MainEvent_event1;

            mainController = main;
            content = contentControl;

            time.Text = DateTime.Now.ToString("HH:mm:ss");
            date.Text = DateTime.Now.ToString("dd MMM yyyy");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Work;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();


            if (Properties.Settings.Default.Admin) { ProgramSettings.Visibility = Visibility.Visible; }
            else { ProgramSettings.Visibility = Visibility.Collapsed; }

            if (contentArea == "Alarms")
            {
                ContentArea.Content = new Alarms(content, mainController);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(AlarmRect, AlarmTriangle);
                selected = "Alarm";
            }
            else if(contentArea == "Settings")
            {
                ContentArea.Content = new Settings(content, mainController);
                SetChoosen(SettingsRect, SettingsTriangle);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                selectedInner = "Settings";
            }
            else if (contentArea == "ProgramSettings")
            {
                ContentArea.Content = new ProgramSettings(content, mainController);
                SetChoosen(ProgramSettingsRect, ProgramSettingsTriangle);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                selected = "ProgramSettings";
            }
            else
            {
                ContentArea.Content = new Image(content, mainController);
            }
        }

        private void MainEvent_event1(object sender, MainEvent e)
        {
            list = e.list;

            Dispatcher.Invoke(() =>
            {
                try
                {
                    gMakinaActualHiz.Text = list[0].ToString();
                    gAnaHizSetMdk.Text = list[1].ToString();
                    gOtomatikHiz.Text = list[2].ToString();
                    gMakinaDurumWord.Content = list[3].ToString();

                    gMakinaActualHizValue = Convert.ToDouble(list[0]);
                    gAnaHizSetMdkValue = Convert.ToDouble(list[1]);
                }
                catch { }
            });
        }

        private void Timer_Work(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");
            date.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void Rozamac_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new StartPage(content, mainController);
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            if (selected != "HomePage")
            {
                Image.Visibility = Visibility.Visible;
                NumberLogic.Visibility = Visibility.Visible;
                LineSchema.Visibility = Visibility.Visible;

                setSelectedInner();

                HomeRect.Fill = Brushes.Orange;
                HomeTriangle.Visibility = Visibility.Visible;
                selected = "HomePage";
            }
        }

        private void setSelectedInner()
        {
            switch (selectedInner)
            {
                case "Image":
                    ContentArea.Content = new Image(content, mainController);
                    selectedInner = "Image";
                    SetChoosen(ImageRectangle, ImageTriangle);
                    break;
                case "NumberLogic":
                    ContentArea.Content = new NumberLogic(content, mainController);
                    selectedInner = "NumberLogic";
                    SetChoosen(NumberLogicRect, NumberLogicTriangle);
                    break;
                case "LineSchema":
                    ContentArea.Content = new LineSchema(content, mainController);
                    selectedInner = "LineSchema";
                    SetChoosen(LineRect, LineTriangle);
                    break;
            }
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            if (selectedInner != "Image")
            {
                ContentArea.Content = new Image(content, mainController);
                SetChoosen(ImageRectangle, ImageTriangle);
                HomeRect.Fill = Brushes.Orange;
                HomeTriangle.Visibility = Visibility.Visible;
                selectedInner = "Image";
            }
        }

        private void NumberLogic_Click(object sender, RoutedEventArgs e)
        {
            if (selectedInner != "NumberLogic")
            {
                ContentArea.Content = new NumberLogic(content, mainController);
                SetChoosen(NumberLogicRect, NumberLogicTriangle);
                HomeRect.Fill = Brushes.Orange;
                HomeTriangle.Visibility = Visibility.Visible;
                selectedInner = "NumberLogic";
            }
        }

        private void LineSchema_Click(object sender, RoutedEventArgs e)
        {
            if (selectedInner != "LineSchema")
            {
                ContentArea.Content = new LineSchema(content, mainController);
                SetChoosen(LineRect, LineTriangle);
                HomeRect.Fill = Brushes.Orange;
                HomeTriangle.Visibility = Visibility.Visible;
                selectedInner = "LineSchema";
            }
        }

        private void Alarm_Click(object sender, RoutedEventArgs e)
        {
            if (selected != "Alarm")
            {
                ContentArea.Content = new Alarms(content, mainController);

                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(AlarmRect, AlarmTriangle);
                selected = "Alarm";
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (selected != "Settings" && Properties.Settings.Default.SignedIn)
            {
                ContentArea.Content = new Settings(content, mainController);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(SettingsRect, SettingsTriangle);
                selected = "Settings";
            }
        }

        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            UserSelectionPage userSelectionPage = new UserSelectionPage(content, mainController);
            userSelectionPage.ShowDialog();
        }

        private void Warning_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetChoosen(Rectangle rectangle, Polygon triangle)
        {
            ImageRectangle.Fill = Brushes.Black;
            NumberLogicRect.Fill = Brushes.Black;
            LineRect.Fill = Brushes.Black;
            AlarmRect.Fill = Brushes.Black;
            SettingsRect.Fill = Brushes.Black;
            HomeRect.Fill = Brushes.Black;
            ProgramSettingsRect.Fill = Brushes.Black;

            ImageTriangle.Visibility = Visibility.Collapsed;
            NumberLogicTriangle.Visibility = Visibility.Collapsed;
            LineTriangle.Visibility = Visibility.Collapsed;
            AlarmTriangle.Visibility = Visibility.Collapsed;
            SettingsTriangle.Visibility = Visibility.Collapsed;
            HomeTriangle.Visibility = Visibility.Collapsed;
            ProgramSettingsTriangle.Visibility = Visibility.Collapsed;

            rectangle.Fill = Brushes.Orange;
            triangle.Visibility = Visibility.Visible;
        }

        private void ProgramSettings_Click(object sender, RoutedEventArgs e)
        {
            if (selected != "ProgramSettings" && Properties.Settings.Default.Admin)
            {
                ContentArea.Content = new ProgramSettings(content, mainController);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(ProgramSettingsRect, ProgramSettingsTriangle);
                selected = "Settings";
            }
        }

        private void gOtomatikGit_TouchDown(object sender, TouchEventArgs e)
        {
            gOtomatikGitBool = !gOtomatikGitBool;
            mainController.Write_gOtomatikGit(gOtomatikGitBool);
        }

        public double gMakinaActualHizValue
        {
            get { return _gMakinaActualHizValue; }
            set
            {
                _gMakinaActualHizValue = value;
            }
        }

        public double gAnaHizSetMdkValue
        {
            get { return _gAnaHizSetMdkValue; }
            set
            {
                _gAnaHizSetMdkValue = value;
            }
        }
    }
}
