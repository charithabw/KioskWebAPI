using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IPermissionService
    {
        Task<KioskResponse> GetPermissionByRoleIDAndScreenID(int roleID, int screenID);
    }
}
