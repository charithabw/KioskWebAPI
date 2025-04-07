using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Services;
using KioskWebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        [Route("GetProductImageByProductNameID")]
        public async Task<KioskResponse> GetProductImageByProductNameID(int productNameID)
        {
            var item = await _productImageService.GetProductImageByProductNameID(productNameID);
            return item;
        }
    }
}
