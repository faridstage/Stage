using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        [Key]
        public string id { get; set; }

        [Required(ErrorMessage = "you have to provide a valid First name")]
        [MinLength(2, ErrorMessage = "min is 2")]
        [MaxLength(20, ErrorMessage = "max is 20")]
        public string Name { get; set; }
        [Required(ErrorMessage = "you have to provide a valid Email")]
        [EmailAddress(ErrorMessage = "you have to provide a valid Email")]
        public string Email { get; set; }

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

        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
