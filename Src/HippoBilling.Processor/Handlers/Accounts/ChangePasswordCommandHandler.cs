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
    public class ChangePasswordCommandHandler:CommandHandlerBase<ChangePasswordCommand>
    {
        public override void Handle(ChangePasswordCommand command)
        {
          var passwordRecovery= Repository.Query<PasswordRecovery>().Where(x => x.VerioficationCode.ToString().Equals(command.VerificationCode, StringComparison.CurrentCultureIgnoreCase) && !x.Used).FirstOrDefault();
          if (passwordRecovery == null) throw new ErrorException("The verification code is no available.");

          passwordRecovery.Use(command.Password);

          Repository.Update(passwordRecovery);
          
        }
    }
}
