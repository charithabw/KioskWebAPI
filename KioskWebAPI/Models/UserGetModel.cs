// File: Kiosk.WebAPI/Models/UserGetModel.cs
using System;

namespace Kiosk.WebAPI.Models
{
    public class UserGetModel
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool IsLock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? RoleName { get; set; }
    }
}
