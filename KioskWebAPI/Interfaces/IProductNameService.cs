using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IProductNameService
    {
        Task<KioskResponse> GetProductName(int CategoryID);
    }
}
