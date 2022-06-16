using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;

namespace Stage_Books.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int phone { get; set; }
        public string gender { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string Nlanguage { get; set; }
        public string work { get; set; }
        public DateTime birth { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }
    }
}
