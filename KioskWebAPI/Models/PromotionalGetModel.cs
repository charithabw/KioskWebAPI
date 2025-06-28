namespace Kiosk.WebAPI.Models
{
    public class PromotionalGetModel
    {

        public int PromotionalID { get; set; }
        public string? PromotionalName { get; set; }
        public string? PromotionalDesc { get; set; }
        public bool IsActive { get; set; }
        public string? ImagePath { get; set; }

        public string? Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
       

    }
}




