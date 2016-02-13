using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HippoBilling.Domain.Practices;

namespace HippoBilling.Web.Models.Authorizations
{
    public class AuthorizationOptionsViewModel
    {
        public IEnumerable<SelectListItem> ProviderOptions { get; set; }

        public IEnumerable<SelectListItem> LocationOptions { get; set; }

        public Practice CurrentPractice { get; set; }
    }
}