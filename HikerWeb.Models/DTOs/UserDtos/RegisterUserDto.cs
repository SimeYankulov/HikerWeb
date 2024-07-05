using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerWeb.Models.DTOs.UserDtos
{
    public class RegisterUserDto
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DOB { get; set; }
        public int ClubId { get; set; }

    }
}
