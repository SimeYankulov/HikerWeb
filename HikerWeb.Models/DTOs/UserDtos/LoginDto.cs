using System.ComponentModel.DataAnnotations;

namespace HikerWeb.Models.DTOs.UserDtos
{
    public class LoginDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [MinLength(5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
