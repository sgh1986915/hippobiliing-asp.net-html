using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Addresses;

namespace HippoBilling.Service.Addresses
{
    public interface IStateService
    {
        List<State> GetAllStates();
        State GetState(string code);
    }
}