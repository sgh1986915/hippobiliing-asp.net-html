using HippoBilling.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Commands.Accounts
{
    public class ChangePasswordCommand:ICommand
    {
        public string VerificationCode { get; set; }
        public string Password { get; set; }
    }
}
