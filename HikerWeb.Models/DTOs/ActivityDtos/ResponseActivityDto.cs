using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Models.DTOs.ClubDtos;

namespace HikerWeb.Models.DTOs.Activity
{
    public class ResponseActivityDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string ImageLink { get; set; }

        public ActivityTypeDto ActivityType { get; set; }
        public ResponseClubDto Club { get; set; }
    }
}
