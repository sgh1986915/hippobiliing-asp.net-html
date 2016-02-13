using HippoBilling.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Commands.Accounts
{
    public class ActiveUsersCommand:ICommand
    {
        public List<Guid> UserIds { get; set; }
    }
}
