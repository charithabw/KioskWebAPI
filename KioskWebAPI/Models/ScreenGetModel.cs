namespace Kiosk.WebAPI.Models
{
    public class ScreenGetModel
    {   
        public int ScreenID { get; set; }
        public string? ScreenCode { get; set; }
        public string? ScreenName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }



    }
}
