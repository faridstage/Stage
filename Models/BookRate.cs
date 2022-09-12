using System.ComponentModel.DataAnnotations.Schema;
namespace Stage_Books.Models
{
    public class BookRate
    {
        public int id { get; set; }
        public int RateCount { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }

 }


