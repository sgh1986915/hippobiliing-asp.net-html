using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Event
{
    public class AsyncEventEmitter:IAsyncEventEmitter
    {
        private readonly IWindsorContainer _container;

        public AsyncEventEmitter(IWindsorContainer container)
        {
            _container = container;
        }
        public void Emit<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = _container.ResolveAll<IEventHandler<TEvent>>();
          
            Parallel.ForEach(eventHandlers, handler => handler.Handle(@event));
        }
    }
}
