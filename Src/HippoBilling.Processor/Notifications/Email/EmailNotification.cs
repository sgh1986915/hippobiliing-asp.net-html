using HippoBilling.Core.Event;
using HippoBilling.Processor.Events.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Notifications.Email
{
    public class EmailNotification : IEventHandler<SendVerificationEvent>
    {
        public void Handle(SendVerificationEvent evt)
        {
            string message = "Hi, <br /> You request a verification code to chagne your password. <br/> Please click the link {Link} to change your password!";
            EmailProvider.Send(evt.Email, "Password recovery - Verification code", message.Replace("{Link}", evt.Link));
        }
    }
}
