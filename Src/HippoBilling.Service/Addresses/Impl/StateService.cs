using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Addresses;

namespace HippoBilling.Service.Addresses.Impl
{
    public class StateService : ServiceBase, IStateService
    {
        public List<Domain.Addresses.State> GetAllStates()
        {
            return Repository.Query<State>().ToList();
        }

        public State GetState(string code)
        {
            return Repository.Query<State>().FirstOrDefault(x => x.Code.Equals(code,StringComparison.CurrentCultureIgnoreCase));
        }
    }
}