using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Antiques
    {
        
        public int id { get; set; }
        [Required]
        [Display(Name = "اسم القطعة ")]
        public string Name { get; set; }
        [Display(Name = "تاريخ الصنع ")]
        public string date { get; set; }
        [Display(Name = "  صنع فى")]
        public string madein { get; set; }
        [Display(Name = "   الصانع")]
        public string creator { get; set; }


        [Display(Name = "المالك ")]
        public string owner { get; set; }
        [Display(Name = "  توثيق الملكية ")]
        public string ownercerti { get; set; }
        [Display(Name = " صورة القطعة")]
        public string imageurl { get; set; }
        [Display(Name = "وصف القطعة")]
        public string des { get; set; }
        [Display(Name = "معلومات القطعة")]
        public string info { get; set; }
        [Display(Name = "اخرى")]
        public string note { get; set; }
    }
}
