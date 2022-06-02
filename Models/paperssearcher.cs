using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class paperssearcher
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Searcher Name")]
        public string searchername { get; set; }

        [Required]
        [Display(Name = "Serch Name")]
        public string SerchName { get; set; }

        [Required]
        [Display(Name = "Topic")]
        public string topic { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string lang { get; set; }

        [Required]
        [Display(Name = "Pages Number")]
        public string PagesNumber { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public string publishdate { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string category { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string image { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string url { get; set; }

        [Display(Name = "Notes")]
        public string note { get; set; }
    }
}
