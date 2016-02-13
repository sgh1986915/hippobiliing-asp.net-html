using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Handlers.Accounts
{
    public class CreateUserCommandHandler:CommandHandlerBase<CreateUserCommand>
    {
        public override void Handle(CreateUserCommand command)
        {
            var practice = Repository.Get<Practice>(command.PracticeId);
            if(practice==null) throw new ErrorException("The practice does not exist.");
            var user =Repository.Query<User>().FirstOrDefault(x => x.Email.Equals(command.Email, StringComparison.CurrentCultureIgnoreCase));
            var isNewAccount = user == null;

            if (!isNewAccount && !IsNewPracticeUser(command.PracticeId,command.Email)) throw new ErrorException("The user account already existed in this practice.");

            user = user ?? new User();
            user.Email = command.Email;
            user.Name = command.Name;
            user.Active = command.Active;
            user.Role = isNewAccount ? Role.Custom : user.Role;
            user.Id = isNewAccount ? command.Id : user.Id;
            user.Password = isNewAccount
                ? PasswordHasher.HashedPassword(command.Id.ToString("N").Substring(0, 6))
                : user.Password;

            var practiceUser = new PracticeUser() {User = user, Practice = practice};
            Repository.Create(practiceUser);
        }
        private bool IsNewPracticeUser(Guid practiceId, string email)
        {
          return  !Repository.Query<PracticeUser>()
                .Any(x =>x.PracticeId == practiceId &&x.User.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
