using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Event
{
    public interface IAsyncEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent evt);
    }
}
