using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozamac.Events
{
    public class MainEvent : EventArgs
    {
        public IList<object> list;
        public static event EventHandler<MainEvent> event1;

        public MainEvent() { }

        public MainEvent(IList<object> lists)
        {
            list = lists;
        }

        protected virtual void onDataReceived(MainEvent e)
        {
            event1?.Invoke(this, e);
        }

        public void sendEventInfo(IList<object> list)
        {
            onDataReceived(new MainEvent(list));
        }
    }
}
