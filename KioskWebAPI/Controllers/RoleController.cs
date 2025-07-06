using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using Kiosk.WebAPI.Services;
using KioskWebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    //changed api path
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetRole")]
        public async Task<KioskResponse> GetRole()
        {
            var item = await _roleService.GetRole();
            return item;
        }

        [HttpPost]
        [Route("SaveRole")]
        public async Task<KioskResponse> SaveRole(RoleSaveModel item)
        {
            return await _roleService.SaveRole(item);
        }

        [HttpPut]
        [Route("UpdateRole/{roleId}")]
        public async Task<KioskResponse> UpdateRole(int roleId, [FromBody] RoleUpdateModel item)
        {
            return await _roleService.UpdateRole(roleId, item);
        }
    }
}
