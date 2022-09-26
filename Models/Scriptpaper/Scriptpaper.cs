using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Scriptpaper
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "مخطوطة")]
        public string scriptname { get; set; }

        [Required]
        [Display(Name = "وصف")]
        public string scriptdiscription { get; set; }

        [Required]
        [Display(Name = "اللغة")]
        public string scriptlang { get; set; }

        [Required]
        [Display(Name = "تفاصيل الاكتشاف ")]
        public string scriptdiscovored { get; set; }

        [Required]
        [Display(Name = " تاريخ الاكتشاف")]
        public string scriptdiscovoreddate { get; set; }

        [Required]
        [Display(Name = "موقع الاكتشاف")]
        public string scriptdiscovoredpalce { get; set; }

        [Required]
        [Display(Name = " الكاتب")]
        public string scriptwriterby { get; set; }

        [Required]
        [Display(Name = "موضوع المخطوطة")]
        public string scripttopic { get; set; }

        [Required]
        [Display(Name = "تاريخ المخطوطة")]
        public string scriptdate { get; set; }

        [Required]
        [Display(Name = "تصنيف")]
        public string scriptcategory { get; set; }

        [Required]
        [Display(Name = "كود")]
        public string scriptcode { get; set; }

        [Required]
        [Display(Name = "محفوظ فى")]
        public string scriptpalcestore { get; set; }

 
        [Display(Name = "صورة")]
        public string scriptimage { get; set; }

        [Display(Name = "ملف")]
        public string scripturl { get; set; }

        [Display(Name = "ملاحظات")]
        public string scriptnote { get; set; }
    }
}
