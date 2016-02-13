using HippoBilling.Core.Event;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Processor.Commands.Accounts;
using HippoBilling.Processor.Events.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Handlers.Accounts
{
    public class SendVerificationCommandHandler:CommandHandlerBase<SendVerificationCommand>
    {
        public override void Handle(SendVerificationCommand command)
        {
            var user = Repository.Query<User>().FirstOrDefault(x => x.Email.Equals(command.Email, StringComparison.CurrentCultureIgnoreCase));
            if (user == null) throw new ErrorException("The user does not exist.");
            var verificationCode = Repository.Query<PasswordRecovery>().OrderByDescending(x => x.RequestDate).FirstOrDefault(x => x.User.Email.Equals(command.Email,StringComparison.CurrentCultureIgnoreCase) && !x.Used);
            verificationCode = verificationCode ?? Repository.Create(PasswordRecovery.CreateNew(user));
            EventPublisher.Emit(new SendVerificationEvent() { Email=command.Email,Link=command.Link+verificationCode.VerioficationCode.ToString() });
        }

    }
}
