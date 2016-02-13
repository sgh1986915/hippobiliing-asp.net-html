using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Accounts;

namespace HippoBilling.Domain.Patients
{
    public class PatientNote : Entity
    {
        public string Detail { get; set; }
        public virtual User CreatedBy { get; set; }
        public NoteLevel Level { get; set; }
        public virtual Patient Patient { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public virtual User LastUpdatedBy { get; set; }
    }
}