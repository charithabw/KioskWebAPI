namespace Kiosk.WebAPI.Models
{
    public class FeedbackSaveModel
    {
        public int EmojiID { get; set; }
        public int ScreenID { get; set; }
        public string? Feedback { get; set; }
        public string? CusName {  get; set; } 
        public string? CusPhone { get; set;}
        public string? CusEmail { get; set; }

    }
}
