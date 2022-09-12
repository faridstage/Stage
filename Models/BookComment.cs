using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class BookComment
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime PublishDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}
