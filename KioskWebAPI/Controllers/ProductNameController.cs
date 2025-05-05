using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using KioskWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductNameController : Controller
    {
        private readonly IProductNameService _productNameService;

        public ProductNameController(IProductNameService productNameService)
        {
            _productNameService = productNameService;
        }

        [HttpGet]
        [Route("GetProductName")]
        public async Task<KioskResponse> GetProductName(int CategoryID)
        {
            var item = await _productNameService.GetProductName(CategoryID);
            return item;
        }

        [HttpPost]
        [Route("SaveProductName")]
        public async Task<KioskResponse> SaveProductName(ProductNameSaveModel item)
        {
            var scrnItem = await _productNameService.SaveProductName(item);
            return scrnItem;
        }

        [HttpPost]
        [Route("UpdateProductName")]
        public async Task<KioskResponse> UpdateProductName(ProductNameUpdateModel item)
        {
            var scrnItem = await _productNameService.UpdateProductName(item);
            return scrnItem;
        }
    }
}
