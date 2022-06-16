using System;

namespace Stage_Books.Models
{
    public class BookComment
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime PublishDate { get; set; }
        public int BookId { get; set; }
        public Book Books { get; set; }
        public int Rating { get; set; }

    }
}
