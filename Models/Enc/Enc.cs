using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;

namespace Stage_Books.Models.Encyclopedia
{
    public class Enc
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Category { get; set; }
        [Required]
        public string Store { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string Poster { get; set; }
    }
}
