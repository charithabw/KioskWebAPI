using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IProductImageService
    {
        Task<KioskResponse> GetProductImageByProductNameID(int productNameID);
        Task<KioskResponse> SaveProductImage(ProductImageSaveModel item);
        Task<KioskResponse> UpdateProductImage(int productImageId, ProductImageUpdateModel item);
    }
}


