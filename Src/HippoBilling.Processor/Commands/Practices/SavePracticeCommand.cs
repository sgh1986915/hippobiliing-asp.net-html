using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Practices
{
    public class SavePracticeCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string FaxNo { get; set; }

        [Required]
        public string TaxId { get; set; }

        [Required]
        public string NPI { get; set; }

        public bool Active { get; set; }

        [Required]
        public Guid Speciality { get; set; }

        [Required]
        public string MailingAddress1 { get; set; }

        public string MailingAddress2 { get; set; }

        [Required]
        public string MailingCity { get; set; }

        [Required]
        public string MailingState { get; set; }

        [Required]
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

        public bool IsNew { get; set; }
    }
}