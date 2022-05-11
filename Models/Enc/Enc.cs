using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models.Encyclopedia
{
    public class Enc
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Category { get; set; }
        [Required]
        public string Store { get; set; }
        public byte[] Poster { get; set; }
    }
}
