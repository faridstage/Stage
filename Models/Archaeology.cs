using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Stage_Books.Models
{
    public class Archaeology
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "اسم الاثر ")]
        public string Name { get; set; }

        
        [Display(Name = " الدولة")]
        public string Country { get; set; }
        
        [Display(Name = " الدولة")]
        public string City { get; set; }

       
        [Display(Name = "تاريخ الاثر")]
        public string date { get; set; }

    
        [Display(Name = "صاحب الاثر")]
        public string creator { get; set; }

        
        [Display(Name = "القائم على الاثر ")]
        public string exename { get; set; }

        [Display(Name = "معلومات ")]
        public string info { get; set; }

      
        [Display(Name = "مكان الاثر")]
        public string place { get; set; }

     
        [Display(Name = "كود الاثر")]
        public string code { get; set; }

        [Display(Name = "صورة الاثر")]
        public string imageurl { get; set; }

        [Display(Name = "ملاحظات")]
        public string note { get; set; }
        //**********************************

  
    }
}
