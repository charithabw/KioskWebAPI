using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KioskWebAPI.Models
{
    
    public class UserLoginResultModel
    {
        
        public string Status { get; set; }
        
        public int? UserId { get; set; }
        
        public string Username { get; set; }
    }
}
