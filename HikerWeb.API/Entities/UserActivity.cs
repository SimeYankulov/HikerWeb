using System.ComponentModel.DataAnnotations.Schema;

namespace HikerWeb.API.Entities
{
    public class UserActivity
    {
        public int Id { get; set; }
       public int UserId { get; set; }
       [ForeignKey("UserId")]
       public User User { get; set; }
       public int ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}
