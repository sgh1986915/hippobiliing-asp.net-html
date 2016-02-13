using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Patients
{
    public class PatientNoteJsonModel
    {
        public Guid Id { get; set; }
        public string Detail { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int Level { get; set; }
        public string LevelString { get; set; }
    }
}