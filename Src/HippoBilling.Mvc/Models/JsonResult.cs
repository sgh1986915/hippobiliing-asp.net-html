using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Mvc.Models
{
    public class CommandResult
    {
        public bool Success { get; set; }

        public string Redirect { get; set; }

        public IEnumerable<ErrorResult> Errors { get; set; }
    }

    public class ErrorResult
    {
        public string Name { get; set; }
        public string Error { get; set; }
    }
}