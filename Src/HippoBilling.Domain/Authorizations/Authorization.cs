using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Practices;
using HippoBilling.Domain.Patients;

namespace HippoBilling.Domain.Authorizations
{
    public class Authorization : Entity
    {
        public virtual Provider Provider { get; set; }
        public virtual Location Location { get; set; }
        public virtual Patient Patient { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Insurance1 { get; set; }
        public string Insurance2 { get; set; }
        public string DX { get; set; }
        public string CPT { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}