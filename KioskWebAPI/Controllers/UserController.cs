using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kiosk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<KioskResponse> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpPost]
        [Route("SaveUser")]
        public async Task<KioskResponse> SaveUser(UserSaveModel item)
        {
            return await _userService.SaveUser(item);
        }

        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public async Task<KioskResponse> UpdateUser(int userId, [FromBody] UserUpdateModel item)
        {
            return await _userService.UpdateUser(userId, item);
        }

    }
}
