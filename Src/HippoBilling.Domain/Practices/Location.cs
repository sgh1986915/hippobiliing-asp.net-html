using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Addresses;

namespace HippoBilling.Domain.Practices
{
    public class Location:Entity
    {
        public string InternalName { get; set; }
        public string InternalCode { get; set; }
        public string NPI { get; set; }

        public virtual ServicePlace PlaceOfService { get; set; }
        public virtual Address Address { get; set; }

        public string Phone { get; set; }

        public string FDA { get; set; }

        public string CLIA { get; set; }

        public bool Active { get; set; }

        public virtual Practice Practice { get; set; }
    }
}
