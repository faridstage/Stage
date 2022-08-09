using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class UserRoleNew
    {
        [StringLength(460)]
        public int id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Account.RegisterViewModel RegisterViewModel { get; set; }
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public AppRole AppRole { get; set; }
    }
}
