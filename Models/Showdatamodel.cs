using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;
using Stage_Books.Models.Account;
using Stage_Books.Models.Contact;
using Stage_Books.Models.Encyclopedia;
using System.Collections.Generic;
using X.PagedList.Mvc.Core;
using X.PagedList;
using System.Linq;

namespace Stage_Books.Models
{
    public class Showdatamodel
    {
        //Author Author = new Author();
        //Book Book = new Book();
        ApplicationDbContext _context;
        public List<Author> Auther { get; set; }
        public List<Book> Books { get; set; }
        public List<Book> Booksearch { get; set; }
        public List<AudioBook> AudioBooks { get; set; } 
        public List<Enc> Encs { get; set; }
        public List<Contactmsg> Contactmsgs { get; set; }
        public List<RegisterViewModel> RegisterViewModel { get; set; }

        public List<Scriptpaper> Scriptpaper { get; set; }

        public List<paperssearcher> paperssearcher { get; set; }
        public List<SaveBook> SaveBooks { get; set; }

        public List<ApplicationUser> appusers { get; set; }

        //public List<Book> Searchfunc(string term)
        //{
        //    var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(term) || b.Author.Name.Contains(term)).ToList();
        //    return result;
        //}
    }
}
