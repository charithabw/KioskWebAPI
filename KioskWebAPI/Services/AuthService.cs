using KioskWebAPI.DBContexts;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KioskWebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _context;
        public AuthService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<UserLoginResultModel> LoginUserAsync(string username, string password)
        {
            var usernameParam = new SqlParameter("@Username", username);
            var passwordParam = new SqlParameter("@Password", password);

            try
            {
                var result = await _context.UserLoginModel
                .FromSqlRaw("EXEC UserLogin @Username, @Password", usernameParam, passwordParam)
                .ToListAsync();

                return result.FirstOrDefault();

            }
            catch(Exception e)
            {
                return null;
            }
            
        }
    }
}
