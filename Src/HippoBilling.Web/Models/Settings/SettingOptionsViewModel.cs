using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoBilling.Web.Models.Settings
{
    public class SettingOptionsViewModel
    {
        public IEnumerable<SelectListItem> StateOptions { get; set; }

        public IEnumerable<SelectListItem> SpecialityOptions { get; set; }

        public IEnumerable<SelectListItem> ServicePlaceOptions { get; set; } 

    }
}