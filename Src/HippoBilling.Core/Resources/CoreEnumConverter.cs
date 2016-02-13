using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Enum;

namespace HippoBilling.Core.Resources
{
    public class CoreEnumConverter : ResourceConverter
    {
        public CoreEnumConverter(Type type)
            : base(type, CoreResource.ResourceManager)
        {
        }
    }
}
