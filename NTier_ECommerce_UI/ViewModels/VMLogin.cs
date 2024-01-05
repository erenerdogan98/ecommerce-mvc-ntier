using System.ComponentModel.DataAnnotations;


namespace NTier_ECommerce_Entities.ViewModels
{
    public class VMLogin
    {
            [Display(Name = "Email address")]
            [Required(ErrorMessage = "Email address is required")]
            public string EmailAddress { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    }
}
