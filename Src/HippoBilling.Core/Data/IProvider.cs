using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Data
{
    public interface IProvider<out T>
    {
        T Get();
    }
}
