using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter the email address.")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage="Please enter the password.")]
        [StringLength(15,MinimumLength = 6, ErrorMessage = "Please enter at least 6 characters.")]
        public string Password { get; set; }
    }
}