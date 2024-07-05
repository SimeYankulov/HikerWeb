using System.ComponentModel.DataAnnotations;

namespace HikerWeb.Models.DTOs.Activity
{
    public class UpdateActivityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is mandatory")]
        [MinLength(3)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is mandatory")]
        [MinLength(3)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Difficulty is mandatory")]
        public int Difficulty { get; set; }
        [Required(ErrorMessage = "Elevation is mandatory")]
        public int Elevation { get; set; }
        [Required(ErrorMessage = "Distance is mandatory")]
        public int Distance { get; set; }
        [Required(ErrorMessage = "Conditions is mandatory")]
        public string Conditions { get; set; }
        [Required(ErrorMessage = "Date is mandatory")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Place is mandatory")]
        public string Place { get; set; }
        [Required(ErrorMessage = "StartPoint is mandatory")]
        public string StartPoint { get; set; }
        [Required(ErrorMessage = "EndPoint is mandatory")]
        public string EndPoint { get; set; }
        public string ImageLink { get; set; }

    }
}
