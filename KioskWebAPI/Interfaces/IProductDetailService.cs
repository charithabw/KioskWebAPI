using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IProductDetailService
    {
        Task<KioskResponse> GetProductDetailByProductNameID(int productNameID);
        Task<KioskResponse> SaveProductDetail(ProductDetailSaveModel item);
    }
}
