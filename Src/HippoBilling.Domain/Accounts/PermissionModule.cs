using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Accounts
{
    public class PermissionModule:Entity
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public int Level { get; set; }

        public int Order { get; set; }

        public virtual PermissionModule Parent { get; set; }

    }
}
