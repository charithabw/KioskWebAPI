namespace Kiosk.WebAPI.Models
{
    public class PermissionGetModel
    {
        public int PermissionID { get; set; }
        public string? PermissionName { get; set; }
        public string? PermissionCode { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }    
        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }    
    }
}
