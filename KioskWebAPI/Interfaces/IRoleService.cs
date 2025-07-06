using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IRoleService
    {
        Task<KioskResponse> GetRole();
        Task<KioskResponse> SaveRole(RoleSaveModel item);
        Task<KioskResponse> UpdateRole(int roleId, RoleUpdateModel item);
    }
}
