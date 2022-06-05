using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Models
{
    public class EditRole
    {
        public EditRole()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }
        [Required(ErrorMessage ="Role Name Is Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
