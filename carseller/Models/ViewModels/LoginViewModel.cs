using System.ComponentModel.DataAnnotations;

namespace carseller.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email address is required")]
        [Display(Name ="Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
