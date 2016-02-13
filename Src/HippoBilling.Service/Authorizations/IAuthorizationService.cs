using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HippoBilling.Domain.Authorizations;

namespace HippoBilling.Service.Authorizations
{
    public interface IAuthorizationService
    {
        List<Authorization> GetAuthorizations(Guid practiceId);
    }
}
