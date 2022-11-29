using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password)
            ,ErrorMessage
            ="Password and confirmation password did not match")]
        public string ConfirmPassword { get; set; }
    }
}
