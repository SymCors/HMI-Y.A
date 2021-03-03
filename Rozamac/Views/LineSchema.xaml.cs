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

namespace Rozamac.Views
{
    /// <summary>
    /// Interaction logic for LineSchema.xaml
    /// </summary>
    public partial class LineSchema : UserControl
    {
        public IList<object> list;
        ContentControl content;
        MainController mainController;

        public LineSchema(ContentControl contentControl, MainController main)
        {
            InitializeComponent();

            LineSchemaEvent.event1 -= LineSchemaEvent_event1;
            LineSchemaEvent.event1 += LineSchemaEvent_event1;

            content = contentControl;
            mainController = main;
        }

        private void LineSchemaEvent_event1(object sender, LineSchemaEvent e)
        {
            list = e.list;
            var res = list[0].ToString();
            Dispatcher.Invoke(() =>
            {
                if (res == "2+2")
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/tpt.jpg"));
                }
                else
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Images/fpz.jpg"));
                }
            });
        }
    }
}
