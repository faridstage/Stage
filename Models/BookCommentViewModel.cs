using System.Collections.Generic;

namespace Stage_Books.Models
{
    public class BookCommentViewModel
    {
        public string Title { get; set; }
        public List<BookComment> ListOfComments { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }


    }
}
