namespace Twitter.ViewModel
{
    using System.ComponentModel.DataAnnotations;
    public class SignInModel
    {
        [Required(ErrorMessage = "required")]
        public string userName { get; set; }
        [Required(ErrorMessage = "required")]
        public string password { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
    }
}


