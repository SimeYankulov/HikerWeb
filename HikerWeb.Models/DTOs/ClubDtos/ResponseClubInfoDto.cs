using System.ComponentModel.DataAnnotations;

namespace HikerWeb.Models.DTOs.ClubDtos
{
    public class ResponseClubInfoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [MinLength(5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is mandatory")]
        [MinLength(5)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Club name is mandatory")]
        [MinLength(5)]
        public string ClubName { get; set; }
        [Required(ErrorMessage = "Date is mandatory")]
        [MinLength(5)]
        public string DateFormed { get; set; }
        [Required(ErrorMessage = "Place is mandatory")]
        [MinLength(5)]
        public string Place { get; set; }
        public string LogoUrl { get; set; }
        public int MembersCount { get; set; }

    }
}
