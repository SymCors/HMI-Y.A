using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozamac.Events
{
    class HomePageEvent : EventArgs
    {
        public IList<object> list;
        public static event EventHandler<HomePageEvent> event1;

        public HomePageEvent() { }

        public HomePageEvent(IList<object> lists)
        {
            list = lists;
        }

        protected virtual void onDataReceived(HomePageEvent e)
        {
            event1?.Invoke(this, e);
        }

        public void sendEventInfo(IList<object> list)
        {
            onDataReceived(new HomePageEvent(list));
        }
    }
}
