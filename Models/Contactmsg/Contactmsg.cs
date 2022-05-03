using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models.Contact
{
    public class Contactmsg
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string mail { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string body { get; set; }
    }
}
