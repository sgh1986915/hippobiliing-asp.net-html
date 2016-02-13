using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Enum;

namespace HippoBilling.Domain.Resources
{
    public class DomainEnumConverter:ResourceConverter
    {
        public DomainEnumConverter(Type type) : base(type, DomainResource.ResourceManager)
        {
        }
    }
}
