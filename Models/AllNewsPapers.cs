using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class AllNewsPapers
    {
        [Key]
        public int Nid { get; set; }

        [Required]
        [Display(Name = "اسم الجريدة ")]
        public string Name { get; set; }
        [Display(Name = "المالك ")]
        public string owner { get; set; }
        [Display(Name = "الدولة ")]
        public string Country { get; set; }
        [Display(Name = "اللوجو ")]
        public string logo { get; set; }
        [Display(Name = "تاريخ التأسيس ")]
        public string newspaperdate { get; set; }
        [Display(Name = "تاريخ اول نسخة ")]
        public string firstpubdate { get; set; }
        [Display(Name = "التصنيف")]
        public string category { get; set; }
        [Display(Name = "اللغة")]
        public string lang { get; set; }
        [Display(Name = "معلومات ")]
        public string desc_info { get; set; }
        [Display(Name = " نوع الجريدة")]
        public string type { get; set; }
        [Display(Name = "ملاحظات ")]
        public string note { get; set; }

        public List<Issuance> Issuances { get; set; }

    }
}
