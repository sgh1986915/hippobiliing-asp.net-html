using HippoBilling.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Service.Accounts
{
    public interface IUserService
    {
        User GetUser(Guid id);
        List<User> GetPracticUsers(Guid practiceId,string keyword,bool active);

        List<UserPermission> GetUserPermissions(Guid practiceId, Guid userId);
    }
}
