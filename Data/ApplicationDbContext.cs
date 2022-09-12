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
        public DbSet<SaveBook> Saved { get; set; }
        //public DbSet<RateBook> RateBooks { get; set; }
        public DbSet<BookComment> BookComments { get; set; }
        public DbSet<AppRole> appRoles { get; set; }
        public DbSet<AppUserRole> appUserRoles { get; set; }
        public DbSet<UserRoleNew> userRoleNews { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<OrderViewModel> orderViewModel { get; set; }
        public DbSet<LoveViewModel> loveViewModels { get; set; }

        public DbSet<BookRate> bookRates { get; set; }
        public DbSet<AdvRequest> advRequest { get; set; }
        public DbSet<AllNewsPapers> allNewsPaper { get; set; }

        public DbSet<Issuance> issuance { get; set; }

        public DbSet<Issuancepaper> issuancepapers { get; set; }    

        public DbSet<PageTitle> pageTitles { get; set; }

        public DbSet<Thesis> theses { get; set; }

        public DbSet<Archaeology> archaeology { get; set; } 

        public DbSet<Archaeology> archaeologies { get; set; }
        public DbSet<Antiques> Antiques  { get; set; }

    }
}
