using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IFeedbackService
    {
        Task<KioskResponse> SaveFeedback(FeedbackSaveModel item);
    }
}
