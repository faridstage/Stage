using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models.Account;
using Stage_Books.Models.Contact;
using Stage_Books.Models.Encyclopedia;

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
    }
}
