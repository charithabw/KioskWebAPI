using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
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
    }
}
