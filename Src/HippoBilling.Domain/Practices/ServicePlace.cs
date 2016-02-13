using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Practices
{
    public class ServicePlace:Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
