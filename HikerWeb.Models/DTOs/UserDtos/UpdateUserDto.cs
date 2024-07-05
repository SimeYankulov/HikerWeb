using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerWeb.Models.DTOs.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(3)]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Last name is mandatory")]
        [MinLength(5)]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [MinLength(5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone number is mandatory")]
        [MinLength(5)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Date of birth is mandatory")]
        [MinLength(6)]
        public string DOB { get; set; }

        [Required(ErrorMessage = "You must upload a picture")]
        [MinLength(6)]
        public string ProfilePicture { get; set; }

    }
}
