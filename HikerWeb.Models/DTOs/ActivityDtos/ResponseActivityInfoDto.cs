using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Models.DTOs.ClubDtos;

namespace HikerWeb.Models.DTOs.Activity
{
    public class ResponseActivityInfoDto
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

        public ResponseClubDto ClubDto { get; set; }
        public ActivityTypeDto Type { get; set; }
    }
}
