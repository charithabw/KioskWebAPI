namespace Kiosk.WebAPI.Models
{
    public class ScreenSaveModel
    {
        public string? ScreenCode { get; set; }
        public string? ScreenName { get; set; }
        public bool? IsActive { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
