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
    public class SaveUserCommandHandler:CommandHandlerBase<SaveUserCommand>
    {
        public override void Handle(SaveUserCommand command)
        {
            var user = Repository.Get<User>(command.Id);
            if (user == null) throw new ErrorException("The user does not exist.");
            if (!user.Email.Equals(command.Email, StringComparison.CurrentCultureIgnoreCase) && CheckEmail(command.Email)) throw new ErrorException("The email addres already existed.");
            user.Email = command.Email;
            user.Name = command.Name;
            user.Active = command.Active;
            Repository.Update(user);
        }

        private bool CheckEmail(string email)
        {
            return Repository.Query<User>().FirstOrDefault(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)) != null;
        }
    }
}
