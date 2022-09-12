using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class LoveViewModel
    {
        public int id { get; set; }
        public int Love_count { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
