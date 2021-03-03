using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KeyPad
{
    /// <summary>
    /// Interaction logic for Keypad.xaml
    /// </summary>
    public partial class Keypad : Window, INotifyPropertyChanged
    {
        private int maxLength;
        private string min, max, value;
        bool newOpened = true;

        #region Public Properties

        private string _result;
        public string Result
        {
            get { return _result; }
            private set { _result = value; this.OnPropertyChanged("Result"); }
        }

        #endregion

        public Keypad()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public Keypad(Window owner, int text_max_length, string min_value, string max_value, string text_value)
        {
            InitializeComponent();
            this.Owner = owner;
            this.DataContext = this;

            maxLength = text_max_length; min = min_value; max = max_value; value = text_value;

            Result = text_value.ToString();
            MinLabel.Content = min_value;
            MaxLabel.Content = max_value;
        }

        private void button_TouchDown(object sender, TouchEventArgs e)
        {
            if (newOpened)
            {
                Result = "";
                newOpened = false;
            }
            Button button = sender as Button;
            switch (button.CommandParameter.ToString())
            {
                case "ESC":
                    this.DialogResult = false;
                    break;

                case "RETURN":
                    try
                    {
                        double value = Convert.ToDouble(Result);
                        if (value > double.Parse(max))
                        {
                            Result = max.ToString();
                        }
                        else if (value < double.Parse(min))
                        {
                            Result = min.ToString();
                        }
                    }
                    catch { Result = value; }
                    this.DialogResult = true;
                    break;

                case "BACK":
                    if (Result.Length > 0)
                        Result = Result.Remove(Result.Length - 1);
                    break;

                default:
                    if (Result == null || Result.Length <= maxLength)
                    {
                        Result += button.Content.ToString();
                    }
                    break;
            }
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_TouchDown(object sender, RoutedEventArgs e)
        {
            if (newOpened)
            {
                Result = "";
                newOpened = false;
            }
            Button button = sender as Button;
            switch (button.CommandParameter.ToString())
            {
                case "ESC":
                    this.DialogResult = false;
                    break;

                case "RETURN":
                    try
                    {
                        double value = Convert.ToDouble(Result);
                        if (value > double.Parse(max))
                        {
                            Result = max.ToString();
                        }
                        else if (value < double.Parse(min))
                        {
                            Result = min.ToString();
                        }
                    }
                    catch { Result = value; }
                    this.DialogResult = true;
                    break;

                case "BACK":
                    if (Result.Length > 0)
                        Result = Result.Remove(Result.Length - 1);
                    break;

                default:
                    if (Result == null || Result.Length <= maxLength)
                    {
                        Result += button.Content.ToString();
                    }
                    break;
            }
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }



        #endregion
    }
}
