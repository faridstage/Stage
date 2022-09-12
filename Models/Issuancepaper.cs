using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Stage_Books.Models
{
    public class Issuancepaper
    {
        [Key]
        public int ppid { get; set; }

        [Display(Name = "رقم الصفحة  ")]
        public string Pages { get; set; }

        [Display(Name = "النسخة ")]
        public string imageurl { get; set; }

        [Display(Name = "الاصدار")]

        public string Pid { get; set; }
        [ValidateNever]
        public virtual Issuance Issuance { get; set; }



        [Display(Name = "ملاحظات ")]
        public string note { get; set; }

    }
}
