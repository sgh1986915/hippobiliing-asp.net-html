using HippoBilling.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Events.Accounts
{
    public class SendVerificationEvent:IEvent
    {
        public string Email { get; set; }
        public string Link { get; set; }
    }
}
