using Microsoft.AspNetCore.Identity;
using System;

namespace Stage_Books.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int phone { get; set; }
        public string gender { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string Nlanguage { get; set; }
        public string work { get; set; }
        public DateTime birth { get; set; }
    }
}
