namespace HikerWeb.Models.DTOs
{
    public class Message
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string MessageText { get; set; }
    }
}
