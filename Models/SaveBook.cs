using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class SaveBook
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string bookDesc { get; set; }
        public string ImageURL { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser AppUser { get; set; }
    }
}
