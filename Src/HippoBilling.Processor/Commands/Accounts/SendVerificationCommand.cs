using HippoBilling.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Commands.Accounts
{
    public class SendVerificationCommand:ICommand
    {
        public string Email { get; set; }
        public string Link { get; set; }
    }
}
