using HippoBilling.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Service.Accounts
{
    public interface IAuthenticationService
    {
        User GetUser(string email);
        PasswordRecovery GetVerificationCode(string code);
    }
}
