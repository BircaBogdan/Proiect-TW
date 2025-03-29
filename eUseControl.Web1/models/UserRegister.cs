using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web1.Models
{
     public class UserRegister
     {
          [Required]
          [StringLength(30, MinimumLength = 5)]
          public string Username { get; set; }

          [Required]
          [EmailAddress]
          public string Email { get; set; }

          [Required]
          [StringLength(50, MinimumLength = 8)]
          public string Password { get; set; }

          [Required]
          [Compare("Password", ErrorMessage = "Passwords do not match.")]
          public string ConfirmPassword { get; set; }
     }
}