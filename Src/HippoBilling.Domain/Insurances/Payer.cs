using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HippoBilling.Core.Data;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Addresses;

namespace HippoBilling.Domain.Insurances
{
    public class Payer : Entity
    {
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string PayerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}