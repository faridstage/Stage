using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
