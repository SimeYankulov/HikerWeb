

using System.ComponentModel.DataAnnotations.Schema;

namespace HikerWeb.API.Entities
{
    public class PictureLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }  
    }
}
