using System.ComponentModel.DataAnnotations;

namespace HikerWeb.Models.DTOs.Activity
{
    public class AddActivityDto
    {
        [Required(ErrorMessage = "Title is mandatory")]
        [MinLength(5)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is mandatory")]
        [MinLength(5)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Dificulty is mandatory")]
        public int Difficulty { get; set; }
        [Required(ErrorMessage = "Elevation is mandatory")]
        public int Elevation { get; set; }
        [Required(ErrorMessage = "Distance is mandatory")]
        public int Distance { get; set; }
        [Required(ErrorMessage = "Conditions is mandatory")]
        [MinLength(5)]
        public string Conditions { get; set; }
        [Required(ErrorMessage = "Date is mandatory")]
        [MinLength(5)]
        public string Date { get; set; }
        public string Place { get; set; }
        [Required(ErrorMessage = "Start Point is mandatory")]
        [MinLength(5)]
        public string StartPoint { get; set; }
        [Required(ErrorMessage = "End Point is mandatory")]
        [MinLength(5)]
        public string EndPoint { get; set; }
        public string ImageLink { get; set; }
        public int ActivityTypeId { get; set; }
        public int ClubId { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }


    }
}
