namespace HikerWeb.Models.DTOs.ClubDtos
{
    public class RegisterClubDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ClubName { get; set; }
        public string DateFormed { get; set; }
        public string Place { get; set; }
        public string LogoUrl { get; set; }
        public int MembersCount { get; set; }
    }
}
