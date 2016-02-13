using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Processor.Commands.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Handlers.Accounts
{
    public class ActiveUsersCommandHandler:CommandHandlerBase<ActiveUsersCommand>
    {
        public override void Handle(ActiveUsersCommand command)
        {
            if (command.UserIds == null || command.UserIds.Count == 0) throw new ErrorException("Invalid parameter.");
            var users = Repository.Query<User>().Where(x => command.UserIds.Contains(x.Id)).ToList();
            users.ForEach(x => x.Active = true);
            Repository.UpdateRange(users);
        }
    }
}
