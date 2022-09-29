using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Author
    {

        public int ID { get; set; }
        [Required]

        public string Name { get; set; }
        [ValidateNever]
        public List<Book> Employees { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageURL { get; set; }

    }
}
