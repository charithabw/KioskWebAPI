using Kiosk.WebAPI.Models;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using System.Threading.Tasks;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IUserService
    {
        Task<KioskResponse> GetUsers();
        Task<KioskResponse> SaveUser(UserSaveModel item);
        Task<KioskResponse> UpdateUser(int userId, UserUpdateModel item);
    }
}
