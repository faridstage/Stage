using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Stage_Books.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display( Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "WhatsApp Phone")]
        public string Whatsapp_phone { get; set; }
        [Display(Name = "Other Way To Contact")]
        public string Other_way_Contact { get; set; }
        [Required]
        public string Book_name { get; set; }
        [Display(Name = "Address of delivery of the book")]
        public string Address { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
