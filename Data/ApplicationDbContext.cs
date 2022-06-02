using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models.Account;
using Stage_Books.Models.Contact;
using Stage_Books.Models.Encyclopedia;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace Stage_Books.Models
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<RegisterViewModel> users { get; set; }
        public DbSet<Contactmsg> Contactmsgs { get; set; }
        public DbSet<Enc> Encs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }
        public DbSet<Scriptpaper> Scriptpaper { get; set; }
        public DbSet<paperssearcher> paperssearchers { get; set; }
    }
}
