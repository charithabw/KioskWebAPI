using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KioskWebAPI.Controllers
{
    public class HomeScreenController : Controller
    {
        private readonly IHomeScreenService _homeScreenService;

        public HomeScreenController(IHomeScreenService homeScreenService)
        {
            _homeScreenService = homeScreenService;
        }

        [HttpPost]
        [Route("SaveHomeScreen")]
        public async Task<KioskResponse> SaveHomeScreen(HomeScreenSaveModel item)
        {
            var scrnItem = await _homeScreenService.SaveHomeScreen(item);
            return scrnItem;
        }
        [HttpGet]
        [Route("GetHomeScreen")]
        public async Task<KioskResponse> GetHomeScreen()
        {
            var scrnItem = await _homeScreenService.GetHomeScreen();
            return scrnItem;
        }
    }
}
