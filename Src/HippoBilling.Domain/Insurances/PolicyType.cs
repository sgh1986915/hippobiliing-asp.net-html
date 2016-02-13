using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Insurances
{
    public class PolicyType : Entity
    {
        public string Name { get; set; }
    }
}