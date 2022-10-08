using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class magazines
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم المجلة ")]
        public string Name { get; set; }

        [Display(Name = "المؤسس ")]
        public string owner { get; set; }

        [Display(Name = "الدولة ")]
        public string Country { get; set; }

        [Display(Name = "اللوجو ")]
        public string logo { get; set; }

        [Display(Name = "تاريخ التأسيس ")]
        public string startdate { get; set; }

        [Display(Name = "تاريخ اول نسخة ")]
        public string firstpubdate { get; set; }

        [Display(Name = "التصنيف")]
        public string category { get; set; }

        [Display(Name = "اللغة")]
        public string lang { get; set; }

        [Display(Name = "معلومات ")]
        public string desc_info { get; set; }

        public List<magazincopys> magazincopys { get; set; }






    }
}
