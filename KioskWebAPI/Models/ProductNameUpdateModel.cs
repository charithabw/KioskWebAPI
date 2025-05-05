namespace Kiosk.WebAPI.Models
{
    public class ProductNameUpdateModel
    {
        public int ProductNameID { get; set; }
        public int CategoryID { get; set; }
        public string? ProdEng { get; set; }
        public string? ProdSin { get; set; }
        public string? ProdTam { get; set; }
        public int ModifiedBy { get; set; }
    }
}
