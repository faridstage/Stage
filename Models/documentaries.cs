using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class documentaries
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم العمل")]
        public string DocName { get; set; }
        [Required]
        [Display(Name = "المنتج")]
        public string Produce { get; set; }
        [Required]
        [Display(Name = "التصنيف")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "عرض فى")]
        public string Publisher { get; set; }

        [Display(Name = "تاريخ العرض")]
        public string PubDate { get; set; }
        [Display(Name = "اللغة")]
        public string Language { get; set; }
        [Display(Name = "حقوق النشر")]
        public string Rights { get; set; }
        [Display(Name = "الفيلم")]
        public string pathdocFile { get; set; }

        [Display(Name = "صورة")]
        
        public string ImageURL { get; set; }
        [Display(Name = "معلومات اخرى")]
        public string note { get; set; }
    }
}
