using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class paperssearcher
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "البحث")]
        public string SerchName { get; set; }

        [Required]
        [Display(Name = "اسم الباحث ")]
        public string searchername { get; set; }

       

        [Required]
        [Display(Name = "الموضوع")]
        public string topic { get; set; }

        [Required]
        [Display(Name = "اللغة")]
        public string lang { get; set; }

        [Required]
        [Display(Name = "الصفحات ")]
        public string PagesNumber { get; set; }

        
        [Display(Name = "تاريخ البحث ")]
        public string publishdate { get; set; }

        [Required]
        [Display(Name = "التصنيف")]
        public string category { get; set; }

     
        [Display(Name = "صورة")]
        public string image { get; set; }

        
        [Display(Name = "ملف البحث")]
        public string url { get; set; }

        [Display(Name = "ملاحظات")]
        public string note { get; set; }
    }
}
