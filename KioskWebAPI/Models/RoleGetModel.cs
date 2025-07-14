namespace Kiosk.WebAPI.Models
{
    public class RoleGetModel
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }


    }
}
