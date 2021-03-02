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
        ContentControl content;
        private string selected = "HomePage";
        private string selectedInner = "Image";
        public MainTemplate(ContentControl contentControl, string contentArea)
        {
            InitializeComponent();
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
                ContentArea.Content = new Alarms(content);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(AlarmRect, AlarmTriangle);
                selected = "Alarm";
            }
            else if(contentArea == "Settings")
            {
                ContentArea.Content = new Settings(content);
                SetChoosen(SettingsRect, SettingsTriangle);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                selectedInner = "Settings";
            }
            else if (contentArea == "ProgramSettings")
            {
                ContentArea.Content = new ProgramSettings(content);
                SetChoosen(ProgramSettingsRect, ProgramSettingsTriangle);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                selected = "ProgramSettings";
            }
            else
            {
                ContentArea.Content = new Image(content);
            }
        }

        private void Timer_Work(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");
            date.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void Rozamac_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new StartPage(content);
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
                    ContentArea.Content = new Image(content);
                    selectedInner = "Image";
                    SetChoosen(ImageRectangle, ImageTriangle);
                    break;
                case "NumberLogic":
                    ContentArea.Content = new NumberLogic(content);
                    selectedInner = "NumberLogic";
                    SetChoosen(NumberLogicRect, NumberLogicTriangle);
                    break;
                case "LineSchema":
                    ContentArea.Content = new LineSchema(content);
                    selectedInner = "LineSchema";
                    SetChoosen(LineRect, LineTriangle);
                    break;
            }
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            if (selectedInner != "Image")
            {
                ContentArea.Content = new Image(content);
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
                ContentArea.Content = new NumberLogic(content);
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
                ContentArea.Content = new LineSchema(content);
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
                ContentArea.Content = new Alarms(content);

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
                ContentArea.Content = new Settings(content);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(SettingsRect, SettingsTriangle);
                selected = "Settings";
            }
        }

        private void Administrator_Click(object sender, RoutedEventArgs e)
        {
            UserSelectionPage userSelectionPage = new UserSelectionPage(content);
            userSelectionPage.ShowDialog();
        }

        private void Warning_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutomaticSpeed_Click(object sender, RoutedEventArgs e)
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
                ContentArea.Content = new ProgramSettings(content);
                Image.Visibility = Visibility.Collapsed;
                NumberLogic.Visibility = Visibility.Collapsed;
                LineSchema.Visibility = Visibility.Collapsed;
                SetChoosen(ProgramSettingsRect, ProgramSettingsTriangle);
                selected = "Settings";
            }
        }
    }
}
