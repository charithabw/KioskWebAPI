
namespace Kiosk.WebAPI.Models
{
    public class ProductImageGetModel
    {
        public int ProductImageID { get; set; }
        public int ProductNameID { get; set; }
        public string? Logo { get; set; }
        public string? QRAndroid { get; set; }
        public string? QRApple { get; set; }
        public string? QRHuawei { get; set; }
        public string? BackgroundImage { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
