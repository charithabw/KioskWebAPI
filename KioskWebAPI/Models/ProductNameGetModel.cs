namespace Kiosk.WebAPI.Models
{
    public class ProductNameGetModel
    {
        public int ProductNameID { get; set; }
        public string? ProdEng { get; set; }
        public string? ProdSin { get; set; }
        public string? ProdTam { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }


    }
}
