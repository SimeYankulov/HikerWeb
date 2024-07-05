using HikerWeb.Models.DTOs.ClubDtos;

namespace HikerWeb.Models.DTOs.UserDtos
{
    public class ResponseUserInfoDto
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DOB { get; set; }
        public ResponseClubDto ClubDto { get; set; }
        public string ProfilePicture { get; set; }
    }
}
