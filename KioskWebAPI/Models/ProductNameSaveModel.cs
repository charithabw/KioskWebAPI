namespace Kiosk.WebAPI.Models
{
    public class ProductNameSaveModel
    {       
        public int CategoryID { get; set; }
        public string? ProdEng { get; set; }
        public string? ProdSin { get; set; }
        public string? ProdTam { get; set; }
        public int CreatedBy { get; set; }
    }
}
