using System.ComponentModel.DataAnnotations;


namespace HippoBilling.Web.Models.Account
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter the password.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Please enter at least 6 characters.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string RetypePassword { get; set; }
    }
}