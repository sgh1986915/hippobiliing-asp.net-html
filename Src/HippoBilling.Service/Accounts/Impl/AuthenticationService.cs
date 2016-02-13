using HippoBilling.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Service.Accounts.Impl
{
    public class AuthenticationService:ServiceBase,IAuthenticationService
    {
        public User GetUser(string email)
        {
            return Repository.Query<User>().FirstOrDefault(u => u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }

        public PasswordRecovery GetVerificationCode(string code)
        {
            return Repository.Query<PasswordRecovery>().Where(x => x.VerioficationCode.ToString().Equals(code, StringComparison.CurrentCultureIgnoreCase) && !x.Used).FirstOrDefault();
        }
    }
}
