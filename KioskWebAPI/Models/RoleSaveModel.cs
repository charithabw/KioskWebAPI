namespace Kiosk.WebAPI.Models
{
    public class RoleSaveModel
    {
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}