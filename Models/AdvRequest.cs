using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class AdvRequest
    {
        // model data
        public int id { get; set; }

        // user data
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Phone Number Supported WhatsApp")]
        public string Phone { get; set; }
        [Display(Name = "Other Way To Connection")]
        public string OtherWay { get; set; }
        [Display(Name = "Date Of Request")]
        public string DateRequest { get; set; }
        // Book data
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }
        public string Language { get; set; }
        [Display(Name = "Book Price")]
        public string Price { get; set; }
        [Display(Name = "Place Of Book")]
        public string PlaceBook { get; set; }
        [Display(Name = "Time Of Adv")]
        public string LongTime { get; set; }
        [Display(Name = "Start In")]
        public string Start { get; set; }
        [Display(Name = "End In")]
        public string End { get; set; }
        [Display(Name = "Book Cover")]
        public string BookCover { get; set; }
        [Display(Name = "Book File")]
        public string BookFile { get; set; }
        [Display(Name = "Book Name")]
        
       
        
        // user id
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
