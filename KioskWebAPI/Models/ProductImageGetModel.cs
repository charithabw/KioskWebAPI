namespace Kiosk.WebAPI.Models
{
    public class ProductImageGetModel
    {
        public int ProductImageID { get; set; }
        public string? Logo { get; set; }
        public string? QRAndroid { get; set; }
        public string? QRApple { get; set; }
        public string? QRHuawei { get; set;}
        public string? BackgroundImage { get; set;}

    }
}
