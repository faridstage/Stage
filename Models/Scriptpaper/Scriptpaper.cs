using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Scriptpaper
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string scriptname { get; set; }

        [Required]
        [Display(Name = "Discription")]
        public string scriptdiscription { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string scriptlang { get; set; }

        [Required]
        [Display(Name = "Discovered Details")]
        public string scriptdiscovored { get; set; }

        [Required]
        [Display(Name = "Discovered Date")]
        public string scriptdiscovoreddate { get; set; }

        [Required]
        [Display(Name = "Discovered place")]
        public string scriptdiscovoredpalce { get; set; }

        [Required]
        [Display(Name = "Writer by")]
        public string scriptwriterby { get; set; }

        [Required]
        [Display(Name = "Topic")]
        public string scripttopic { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string scriptdate { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string scriptcategory { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string scriptcode { get; set; }

        [Required]
        [Display(Name = "Store In")]
        public string scriptpalcestore { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string scriptimage { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string scripturl { get; set; }

        [Display(Name = "Notes")]
        public string scriptnote { get; set; }
    }
}
