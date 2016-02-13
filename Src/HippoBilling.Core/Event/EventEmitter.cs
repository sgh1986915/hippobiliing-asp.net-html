using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Event
{
    public class EventEmitter:IEventEmitter
    {
         private readonly IWindsorContainer _container;

         public EventEmitter(IWindsorContainer container)
        {
            _container = container;
        }
         public void Emit<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = _container.ResolveAll<IEventHandler<TEvent>>();
            foreach (var handler in eventHandlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
