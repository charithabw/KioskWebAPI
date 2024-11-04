using KioskWebAPI.Common;
using KioskWebAPI.Models;

namespace KioskWebAPI.Interfaces
{
    public interface IHomeScreenService
    {
        Task<KioskResponse> SaveHomeScreen(HomeScreenSaveModel item);
    }
}
