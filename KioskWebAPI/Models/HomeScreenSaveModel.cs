namespace KioskWebAPI.Models
{
    public class HomeScreenSaveModel
    {
        public string ScrnHeading { get; set; }
        public byte[] ScrnBannerImg { get; set; }
        public string ScrnParagraph { get; set; }
        public int CreatedBy { get; set; }
    }
}
