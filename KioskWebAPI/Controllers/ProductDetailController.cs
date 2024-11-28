using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        [Route("GetProductDetailByProductNameID")]
        public async Task<KioskResponse> GetProductDetailByProductNameID(int productNameID)
        {
            var item = await _productDetailService.GetProductDetailByProductNameID(productNameID);
            return item;
        }
    }
}
