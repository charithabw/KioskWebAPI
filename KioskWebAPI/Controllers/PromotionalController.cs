using Azure;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using Kiosk.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static KioskWebAPI.Common.KioskEnums;

namespace KioskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionalController : Controller
    {
        private readonly IPromotionalService _promotionalService;

        public PromotionalController(IPromotionalService promotionalService)
        {
            _promotionalService = promotionalService;
        }

        [HttpGet]
        [Route("GetPromotional")]
        public async Task<KioskResponse> GetPromotional()
        {
            var item = await _promotionalService.GetPromotional();
            return item;
        }

        [HttpPost]
        [Route("SavePromotional")]
        public async Task<KioskResponse> SavePromotional(PromotionalSaveModel item)
        {
            var promoItem = await _promotionalService.SavePromotional(item);
            return promoItem;
        }


        [HttpPut]
        [Route("UpdatePromotional/{PromotionalId}")]
        public async Task<KioskResponse> UpdatePromotional(int PromotionalId, [FromBody] PromotionalUpdateModel item)
        {
            var updatedItem = await _promotionalService.UpdatePromotional(PromotionalId, item);
            return updatedItem;
        }
    }
}