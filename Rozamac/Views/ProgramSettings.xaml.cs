using EasyModbus;
using Rozamac.Controllers;
using Rozamac.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Yaskawa.PLCIInterface;

namespace Rozamac.Views
{
    /// <summary>
    /// Interaction logic for ProgramSettings.xaml
    /// </summary>
    public partial class ProgramSettings : UserControl
    {
        ModbusClient modbusClient;
        ContentControl content;
        MainController main;

        private PLCIHandler handler_ = new PLCIHandler();
        private List<string> varList_ = new List<string>();
        private string subscriptionName_ = "MyPLCVariables";
        private bool clicked;

        public ProgramSettings(ContentControl contentControl, MainController mainController)
        {
            InitializeComponent();
            content = contentControl;
            main = mainController;

            PortBox.Text = Properties.Settings.Default.Port;
            IpAddress.Text = Properties.Settings.Default.Ip;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (PortBox.Text == "" || IpAddress.Text == "")
            {
                Error.Visibility = Visibility.Visible;
            }
            else
            {
                Properties.Settings.Default.Port = PortBox.Text;
                Properties.Settings.Default.Ip = IpAddress.Text;
                Properties.Settings.Default.Save();
                content.Content = new StartPage(content, main);
            }
        }

        private void PortBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboards.showKeyboard();
        }

        private void IpAddress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Keyboards.showKeyboard();
        }

        int counter = 0;
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            //ConnectVariables();
            dataToShow.Text = counter++.ToString();
        }



        private void ConnectVariables()
        {
            // clear out any previous connections
            handler_.DisconnectDispose();
            handler_.Connect("192.168.0.2");
            if (handler_.Connected)
            {
                Connection.Fill = Brushes.Green;
            }
            else
            {
                Connection.Fill = Brushes.Red;
            }

            varList_.Add("@GlobalVariables.Deneme");
            varList_.Add("@GlobalVariables.Denem1");
            handler_.Subscribe(subscriptionName_, varList_);
            IList<object> variables = handler_.ReadVariableValues(subscriptionName_);

            handler_.WriteVariableValue("@GlobalVariables.Deneme", 21.0f);
            handler_.WriteVariableValue("@GlobalVariables.Denem1", true);
        }
    }
}
