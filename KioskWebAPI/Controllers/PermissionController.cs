using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    //changed api path
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet]
        [Route("GetAllPermissions")]
        public async Task<KioskResponse> GetAllPermissions()
        {
            return await _permissionService.GetAllPermissions();
        }

        [HttpPost]
        [Route("SavePermission")]
        public async Task<KioskResponse> SavePermission(PermissionSaveModel item)
        {
            return await _permissionService.SavePermission(item);
        }

        [HttpPut]
        [Route("UpdatePermission/{permissionId}")]
        public async Task<KioskResponse> UpdatePermission(int permissionId, [FromBody] PermissionUpdateModel item)
        {
            return await _permissionService.UpdatePermission(permissionId, item);
        }
    }
}
