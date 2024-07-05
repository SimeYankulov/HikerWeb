using System.ComponentModel.DataAnnotations.Schema;

namespace HikerWeb.API.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Dificulty { get; set; }
        public int Elevation { get; set; }
        public int Distance { get; set; }
        public string Conditions { get; set; }
        public string Date { get; set; }
        public string Place { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string ImageLink { get; set; }
        
        public int ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public ActivityType ActivityType { get; set; }

        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public List<UserActivity> UserActivities { get; } = new();

        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
