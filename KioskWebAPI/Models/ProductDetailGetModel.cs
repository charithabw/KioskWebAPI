namespace Kiosk.WebAPI.Models
{
    public class ProductDetailGetModel
    {
        public int ProductDetailID { get; set; }
        public string? TitleEng { get; set; }
        public string? TitleSin { get; set; }
        public string? TitleTam { get; set; }
        public string? DesEng { get; set; }
        public string? DesSin { get; set; }
        public string? DesTam { get; set; }
        public string? SubTitleEng { get; set; }
        public string? SubTitleSin { get; set; }
        public string? SubTitleTam { get; set; }
        public string? PointListEng { get; set; }
        public string? PointListSin { get; set; }
        public string? PointListTam { get; set; }
    }
}
