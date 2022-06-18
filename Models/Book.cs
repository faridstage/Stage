using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Pages { get; set; }
        public string Category { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public DateTime PubDate { get; set; }
        public string Language { get; set; }
        [Required]
        public string Topic { get; set; }
        public string Rights { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageURL { get; set; }

        [Display(Name = "Author")]
        [Range(1, int.MaxValue, ErrorMessage = "Choose a Valid Author")]
        
        public int AuthorID { get; set; }
        [ValidateNever]
        
        public virtual Author Author { get; set; }

        [Display(Name = "BookFile")]
        public string BookURLS { get; set; }

        [Display(Name = "IndexFile")]
        public string IndexURL { get; set; }

        public ICollection<BookComment> BookComment { get; set; }
    }
}
