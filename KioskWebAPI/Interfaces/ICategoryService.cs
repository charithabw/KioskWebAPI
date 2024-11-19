using KioskWebAPI.Common;
using KioskWebAPI.Models;

namespace KioskWebAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<KioskResponse> GetCategory();
        Task<KioskResponse> SaveCategory(CategorySaveModel item);
    }
}
