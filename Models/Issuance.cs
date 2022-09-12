using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class Issuance
    {
        [Key]
        public int Pid { get; set; }

        [Display(Name = "تاريخ النسخة ")]
        public string Issuancedate { get; set; }
        [Display(Name = "عدد الصفحات  ")]
        public string Pages { get; set; }
        [Display(Name = " رقم الاصدار ")]
        public string IssuanceNumber { get; set; }
        [Display(Name = "الجريدة")]
        public string Nid { get; set; }
        [ValidateNever]
        public virtual AllNewsPapers AllNewsPapers { get; set; }

        [Display(Name = "ملاحظات ")]
        public string note { get; set; }
    }
}
