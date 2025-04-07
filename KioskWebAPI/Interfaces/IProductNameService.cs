using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.Models;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IProductNameService
    {
        Task<KioskResponse> GetProductName(int CategoryID);
        Task<KioskResponse> SaveProductName(ProductNameSaveModel item);
    }
}
