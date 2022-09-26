using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class PageTitle
    {
        [Key]
        public int id { get; set; }


        [Display(Name = "عناوين الاخبار ")]
        public string Titles { get; set; }

        [Display(Name = "الصفحة")]

        public int ppid { get; set; }
        [ValidateNever]
      

        [Display(Name = "ملاحظات ")]
        public string note { get; set; }

       
    }
}
