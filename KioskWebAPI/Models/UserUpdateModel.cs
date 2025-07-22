namespace Kiosk.WebAPI.Models
{
    public class UserUpdateModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsLock { get; set; }
    }
}