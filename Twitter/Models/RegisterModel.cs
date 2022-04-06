using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    [Table("Register")]
    public class Register
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string userName { get; set; }
        [Required(ErrorMessage = "required")]
        public string name { get; set; }
        [Required(ErrorMessage = "required")]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "required")]
        public string password { get; set; }
    }
}
