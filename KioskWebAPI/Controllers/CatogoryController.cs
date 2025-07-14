using Azure;
using KioskWebAPI.Common;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using KioskWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static KioskWebAPI.Common.KioskEnums;

namespace KioskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatogoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CatogoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCatorgory")]
        public async Task<KioskResponse> GetCatorgory()
        {
            var item = await _categoryService.GetCategory();
            return item;
        }

        [HttpPost]
        [Route("SaveCategory")]
        public async Task<KioskResponse> SaveCategory(CategorySaveModel item)
        {
            var scrnItem = await _categoryService.SaveCategory(item);
            return scrnItem;
        }


        [HttpPut]
        [Route("UpdateCategory/{CategoryId}")]
        public async Task<KioskResponse> UpdateCategory(int CategoryId, [FromBody] CategoryUpdateModel item)
        {
            var updatedItem = await _categoryService.UpdateCategory(CategoryId, item);
            return updatedItem;
        }
    }
}