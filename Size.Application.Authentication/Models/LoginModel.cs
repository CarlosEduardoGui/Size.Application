using System.ComponentModel.DataAnnotations;

namespace Size.Application.Authentication.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Login { get; set; }
    }
}
