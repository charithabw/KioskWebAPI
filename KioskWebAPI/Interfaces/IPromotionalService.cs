using KioskWebAPI.Common;
using Kiosk.WebAPI.Models;

namespace KioskWebAPI.Interfaces
{
    public interface IPromotionalService
    {
        Task<KioskResponse> GetPromotional();
        Task<KioskResponse> SavePromotional(PromotionalSaveModel item);

        Task<KioskResponse> UpdatePromotional(int PromotionalId, PromotionalUpdateModel item);

    }
}
