using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Thesis
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "اسم الرسالة ")]
        public string Name { get; set; }
        [Display(Name = " الدارس ")]
        public string owner { get; set; }
        [Display(Name = "صورة ")]
        public string image { get; set; }
        [Display(Name = " عرض")]
        public string Thesisurl { get; set; }
        [Display(Name = "تاريخ الرسالة ")]
        public string date { get; set; }
        [Display(Name = "التصنيف")]
        public string category { get; set; }
        [Display(Name = "اللغة")]
        public string lang { get; set; }
        [Display(Name = "موضوع الرسالة ")]
        public string topic { get; set; }
        [Display(Name = " عدد الصفحات ")]
        public string pagesnumber { get; set; }
        [Display(Name = "معلومات ")]
        public string desc_info { get; set; }
        [Display(Name = " نوع الرسالة")]
        public string type { get; set; }
        [Display(Name = "ملاحظات ")]
        public string note { get; set; }
    }
}
