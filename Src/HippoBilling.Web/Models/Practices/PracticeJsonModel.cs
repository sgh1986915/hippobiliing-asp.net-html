using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Practices
{
    public class PracticeJsonModel
    {
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string FaxNo { get; set; }

        public string TaxId { get; set; }

        public string NPI { get; set; }

        public bool Active { get; set; }

        public string Speciality { get; set; }

        public string MailingAddress1 { get; set; }

        public string MailingAddress2 { get; set; }

        public string MailingCity { get; set; }

        public string MailingState { get; set; }

        public string MailingZipCode { get; set; }

        public bool BillingAddrSameAsMailingAddr { get; set; }

        public string BillingAddress1 { get; set; }

        public string BillingAddress2 { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public string BillingZipCode { get; set; }

        public bool PaymentAddrSameAsMailingAddr { get; set; }

        public string PaymentAddress1 { get; set; }

        public string PaymentAddress2 { get; set; }

        public string PaymentCity { get; set; }

        public string PaymentState { get; set; }

        public string PaymentZipCode { get; set; }

    }
}