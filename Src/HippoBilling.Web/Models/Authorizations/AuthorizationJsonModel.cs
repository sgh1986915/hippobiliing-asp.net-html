using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Authorizations
{
    public class AuthorizationJsonModel
    {
        public Guid Id { get; set; }
        public string Patient { get; set; }
        public string Insurance { get; set; }
        public string SubmittedDate { get; set; }
        public string CompletedDate { get; set; }
        public string Provider { get; set; }
        public string Location { get; set; }
    }
}