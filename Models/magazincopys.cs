using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class magazincopys
    {
        public int Id { get; set; }

        [Display(Name = "تاريخ الاصدار ")]
        public string copydate { get; set; }

        [Display(Name = "عدد الصفحات  ")]
        public string Pages { get; set; }

        [Display(Name = " رقم الاصدار ")]
        public string copyNum { get; set; }

        public int magazinesId { get; set; }
        public magazines magazines { get; set; }

        public List<magazinepages> magazinepages { get; set; }
    }
}
