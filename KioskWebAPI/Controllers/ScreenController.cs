using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using Kiosk.WebAPI.Services;
using KioskWebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    public class ScreenController : Controller
    {
        private readonly IScreenService _screenService;
        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        [HttpGet]
        [Route("GetScreen")]
        public async Task<KioskResponse> GetScreen()
        {
            var item = await _screenService.GetScreen();
            return item;
        }

        [HttpPost]
        [Route("SaveScreen")]
        public async Task<KioskResponse> SaveScreen(ScreenSaveModel item)
        {
            var scrnItem = await _screenService.SaveScreen(item);
            return scrnItem;
        }
    }
}
