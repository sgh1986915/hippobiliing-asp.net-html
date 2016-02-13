using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Resources;

namespace HippoBilling.Domain.Practices
{
    [TypeConverter(typeof(DomainEnumConverter))]
    public enum Gender
    {
        Male=0,
        Famle=1
    }
}
