using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marksheet.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }
         [Required]
        [Display(Name = "New Pasword")]
        public string NewPassword { get; set; }
         [Compare("NewPassword", ErrorMessage = "Password Mismatch")]
        [Display(Name = "Confirm Password")]
        public string ConfirmNew { get; set; }
    }
}