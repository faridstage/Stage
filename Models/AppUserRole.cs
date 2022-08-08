using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class AppUserRole
    {
        [StringLength(460)]
        public string Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser AppUser { get; set; }
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public AppRole AppRole  { get; set; }

    }
}
