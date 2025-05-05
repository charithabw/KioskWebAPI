using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;

namespace Kiosk.WebAPI.Interfaces
{
    public interface IScreenService
    {
        Task<KioskResponse> GetScreen();
        Task<KioskResponse> SaveScreen(ScreenSaveModel item);
    }
}
