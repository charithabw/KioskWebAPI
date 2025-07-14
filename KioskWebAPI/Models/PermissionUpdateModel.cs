namespace Kiosk.WebAPI.Models
{
    public class PermissionUpdateModel
    {
        public string? PermissionName { get; set; }
        public string? PermissionCode { get; set; }
        public int ScreenID { get; set; }
        public int RoleID { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanView { get; set; }
        public bool? IsActive { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}