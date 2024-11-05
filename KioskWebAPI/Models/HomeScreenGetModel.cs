namespace KioskWebAPI.Models
{
    public class HomeScreenGetModel
    {
        public int RecordID { get; set; }
        public string ScrnHeading { get; set; }
        public byte[] ScrnBannerImg { get; set; }
        public string ScrnParagraph { get; set; }      
    }
}
