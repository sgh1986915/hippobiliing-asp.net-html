using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace HippoBilling.Web.Models.Navigation
{
    public class MenuItem
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Title { get; set; }
        public string Area { get; set; }

        public object RouteValues { get; set; }
        public bool Active { get; set; }

        public virtual string Template
        {
            get { return string.Format("~/Views/Navigation/Menu/_{0}.cshtml", this.GetType().Name); }
        }
    }

    public class FaMenuItem : MenuItem
    {
        public string Suffix { get; set; }
    }
}