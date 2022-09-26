using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Book> books { get; set; }
    }
}
