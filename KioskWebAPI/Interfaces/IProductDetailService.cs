using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IProductDetailService
    {
        Task<KioskResponse> GetProductDetailByProductNameID(int productNameID);
    }
}
