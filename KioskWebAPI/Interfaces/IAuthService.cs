using KioskWebAPI.Models;

namespace KioskWebAPI.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResultModel> LoginUserAsync(string username, string password);
    }
}
