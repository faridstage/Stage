using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class magazinepages
    {
        public int Id { get; set; }

        [Display(Name = " رقم الصفحة ")]
        public string pageNum { get; set; }

        public int magazincopysId  { get; set; }
        public magazincopys magazincopys { get; set; }

        [Display(Name = " الصفحة ")]
        public string page { get; set; }
    }
}
