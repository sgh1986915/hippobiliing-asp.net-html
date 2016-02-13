using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Addresses;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Domain.Patients
{
    public class FavoritePhysician : Entity
    {
        public Guid PracticeId { get; set; }
        public virtual Practice Practice { get; set; }
        public string NPI { get; set; }
        public string Name { get; set; }
        public bool Organization { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}