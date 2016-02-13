using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Domain.Accounts
{
    [ComplexType]
    public class HashedPassword
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
