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
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public DateTime PubDate { get; set; }
        [Required]
        public DateTime uploadDate { get; set; }
        public string Language { get; set; }
        [Required]
        public string Topic { get; set; }
        public string Rights { get; set; }
        [Required]
        public string path { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageURL { get; set; }
        public string note { get; set; }
    }
}
