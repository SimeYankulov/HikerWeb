using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikerWeb.Models.DTOs.ClubDtos
{
    public class UpdateClubDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [MinLength(5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone is mandatory")]
        [MinLength(5)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Club name is mandatory")]
        [MinLength(5)]
        public string ClubName { get; set; }
        [Required(ErrorMessage = "Date is mandatory")]
        [MinLength(4)]
        public string DateFormed { get; set; }
        [Required(ErrorMessage = "Place is mandatory")]
        [MinLength(5)]
        public string Place { get; set; }
        public string LogoUrl { get; set; }
        public int MembersCount { get; set; }
    }
}
