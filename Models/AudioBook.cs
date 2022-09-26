using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class AudioBook
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        
        public string Publisher { get; set; }
       
        public string Desc { get; set; }
       
        public string PubDate { get; set; }
        
        public string uploadDate { get; set; }
        public string Language { get; set; }
       
        public string Topic { get; set; }
        public string Rights { get; set; }
        [Display(Name = "الكتاب")]
        [ValidateNever]
        public string path { get; set; }

        [Display(Name = "بروفايل")]
        [ValidateNever]
        public string ImageURL { get; set; }
        public string note { get; set; }
    }
}
