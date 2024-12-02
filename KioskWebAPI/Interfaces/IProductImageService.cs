using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IProductImageService
    {
        Task<KioskResponse> GetProductImageByProductNameID(int productNameID); 
    }
}
