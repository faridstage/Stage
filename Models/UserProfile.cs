using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stage_Books.Models
{
    public class UserProfile
    {
        [Display(Name ="Id")]
        public long Id { get; set; }

        [Display(Name ="User Name")]
        public string Name { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name="User Image")]
        public string UserImage { get; set; }
    }
}
