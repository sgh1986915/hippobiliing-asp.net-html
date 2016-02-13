using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Event
{
    public interface IAsyncEventEmitter
    {
        void Emit<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
