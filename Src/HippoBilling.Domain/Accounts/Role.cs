using System.ComponentModel;
using HippoBilling.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Resources;

namespace HippoBilling.Domain.Accounts
{
    [TypeConverter(typeof(DomainEnumConverter))]
    public enum Role
    {
        Admin = 0,
        Staff = 1,
        Provider = 2,
        Custom = 3
    }
}
