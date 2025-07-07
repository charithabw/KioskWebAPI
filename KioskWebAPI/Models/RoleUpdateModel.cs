namespace Kiosk.WebAPI.Models
{
    public class RoleUpdateModel
    {
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}