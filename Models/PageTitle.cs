using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Stage_Books.Models
{
    public class PageTitle
    {
   
        public int id { get; set; }


        [Display(Name = "عناوين الاخبار ")]
        public string Titles { get; set; }

        [Display(Name = "الصفحة")]

        public string ppid { get; set; }
        [ValidateNever]
        public virtual Issuancepaper Issuancepaper { get; set; }



        [Display(Name = "ملاحظات ")]
        public string note { get; set; }
    }
}
