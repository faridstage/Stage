using System;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models.Account
{
    public class RegisterViewModel
    {


        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "you have to provide a valid First name")]
        [MinLength(2, ErrorMessage = "min is 2")]
        [MaxLength(20, ErrorMessage = "max is 20")]
        [Display(Name ="UserName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you have to provide a valid Email")]
        [EmailAddress(ErrorMessage = "you have to provide a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "you have to provide a valid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Passwords does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int phone { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string Nlanguage { get; set; }
        [Required]
        public string work { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime birth { get; set; }

        public string ImageURL { get; set; }
    }
}
