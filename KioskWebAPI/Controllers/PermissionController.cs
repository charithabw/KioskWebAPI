using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [Route("GetPermissionByRoleIDAndScreenID")]
        public async Task<KioskResponse> GetPermissionByRoleIDAndScreenID(int roleID, int screenID)
        {
            var item = await _permissionService.GetPermissionByRoleIDAndScreenID(roleID, screenID);
            return item;
        }
    }
}
