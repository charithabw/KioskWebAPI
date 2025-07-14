namespace Kiosk.WebAPI.Models
{
    public class PromotionalSaveModel
    {
        public string? PromotionalName { get; set; }

        public string? PromotionalDesc { get; set; }

        public bool IsActive { get; set; }
        public string? ImagePath { get; set; }

        public string? Status { get; set; }

        public int CreatedBy { get; set; }

    }
}
