using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Navigation
{
    public class PracticeTabItem
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string Url { get; set; }

        public bool IsNew { get; set; }
        
    }
}