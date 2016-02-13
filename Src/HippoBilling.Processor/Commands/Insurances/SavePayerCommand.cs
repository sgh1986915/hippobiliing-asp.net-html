using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Insurances
{
    public class SavePayerCommand : ICommand
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Fax { get; set; }

        public string PayerId { get; set; }

        public bool IsNew { get; set; }
    }
}