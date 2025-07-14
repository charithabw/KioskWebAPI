using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IPermissionService
    {
        Task<KioskResponse> GetPermissionByRoleIDAndScreenID(int roleID, int screenID);
        Task<KioskResponse> GetAllPermissions();
        Task<KioskResponse> SavePermission(PermissionSaveModel item);
        Task<KioskResponse> UpdatePermission(int permissionId, PermissionUpdateModel item);
    }
}

