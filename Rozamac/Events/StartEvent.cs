using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozamac.Events
{
    public class StartEvent
    {
        public IList<object> list;
        public static event EventHandler<StartEvent> event1;

        public StartEvent() { }

        public StartEvent(IList<object> lists)
        {
            list = lists;
        }

        protected virtual void onDataReceived(StartEvent e)
        {
            event1?.Invoke(this, e);
        }

        public void sendEventInfo(IList<object> list)
        {
            onDataReceived(new StartEvent(list));
        }
    }
}
