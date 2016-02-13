using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Accounts
{
    public class SaveUserPermissionCommand:ICommand
    {
        public Guid UserId { get; set; }

        public Guid PracticeId { get; set; }

        public List<UserPermissionCommand> UserPermissions { get; set; }
    }

    public class UserPermissionCommand
    {
        public string Id { get; set; }
        public bool FullControl { get; set; }
        public bool View { get; set; }
        public bool Edit { get; set; }

        public bool Delete { get; set; }
    }
}
