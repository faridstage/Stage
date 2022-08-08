using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class AppRole
    {
        [StringLength(460)]
        [Key]
        public string Id { get; set; }
        [StringLength(150),Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
