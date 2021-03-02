using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozamac.Events
{
    public class LineSchemaEvent
    {
        public IList<object> list;
        public static event EventHandler<LineSchemaEvent> event1;

        public LineSchemaEvent() { }

        public LineSchemaEvent(IList<object> lists)
        {
            list = lists;
        }

        protected virtual void onDataReceived(LineSchemaEvent e)
        {
            event1?.Invoke(this, e);
        }

        public void sendEventInfo(IList<object> list)
        {
            onDataReceived(new LineSchemaEvent(list));
        }
    }
}
