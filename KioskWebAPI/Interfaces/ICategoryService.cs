using KioskWebAPI.Common;
using KioskWebAPI.Models;

namespace KioskWebAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<KioskResponse> GetCategory();
        Task<KioskResponse> SaveCategory(CategorySaveModel item);

        Task<KioskResponse> UpdateCategory(int CategoryId, CategoryUpdateModel item);
  
    }
}
