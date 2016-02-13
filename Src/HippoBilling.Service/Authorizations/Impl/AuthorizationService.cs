using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HippoBilling.Domain.Authorizations;

namespace HippoBilling.Service.Authorizations.Impl
{
    public class AuthorizationService : ServiceBase, IAuthorizationService
    {
        public List<Authorization> GetAuthorizations(Guid practiceId)
        {
            return 
                Repository.Query<Authorization>()
                    .Where(x => x.Provider.Practice.Id == practiceId).ToList();
        }
    }
}
