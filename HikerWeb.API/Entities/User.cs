using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HikerWeb.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; } = "";
        public string LName { get; set; } = "";
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        [AllowNull]
        public int? ClubId { get; set; }
        [ForeignKey ("ClubId")]
       
        public Club Club { get; set; }

        public string profilePicture { get; set; }
        public List<UserActivity> UserActivities { get; } = new();


    }
}
