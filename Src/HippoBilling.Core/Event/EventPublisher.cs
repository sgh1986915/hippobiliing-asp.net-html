using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Event
{
    public class EventPublisher
    {
        public static void Emit(IEvent @event)
        {
            ServiceLocator.Current.GetInstance<IEventEmitter>().Emit((dynamic)@event);
        }

        public static void AsyncEmit(IEvent @event)
        {
            ServiceLocator.Current.GetInstance<IAsyncEventEmitter>().Emit((dynamic)@event);
        }
    }
}
