using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoBilling.Web.Models.Patients
{
    public class PatientOptionsViewModel
    {
        public IEnumerable<SelectListItem> StateOptions { get; set; }

        public IEnumerable<SelectListItem> ProviderOptions { get; set; }

        public IEnumerable<SelectListItem> PatientStatusOptions { get; set; }

        public IEnumerable<SelectListItem> PolicyTypeOptions { get; set; }
    }
}