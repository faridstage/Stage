using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;
using Stage_Books.Models.Account;
using System.Collections.Generic;

namespace Stage_Books.Models
{
    public class Showdatamodel
    {
        //Author Author = new Author();
        //Book Book = new Book();

        public List<Author> Auther { get; set; }
        public List<Book> Books { get; set; }
        public List<RegisterViewModel> RegisterViewModel { get; set; }

        
    }
}
