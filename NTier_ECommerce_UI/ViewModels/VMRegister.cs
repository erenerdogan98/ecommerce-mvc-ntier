﻿using System.ComponentModel.DataAnnotations;

namespace NTier_ECommerce_UI.ViewModels
{
    public class VMRegister
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Name Surname is required")]
        public string NameSurname { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
