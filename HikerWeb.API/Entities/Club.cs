namespace HikerWeb.API.Entities
{
    public class Club
    {
        public int Id { get; set; }
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