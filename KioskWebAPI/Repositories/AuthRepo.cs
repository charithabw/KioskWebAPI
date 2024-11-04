using KioskWebAPI.DBContexts;
using KioskWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KioskWebAPI.Repositories
{
    public class AuthRepo
    {
        private readonly AppDBContext _context;
        public AuthRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task<UserLoginResultModel> LoginUserAsync(string username, string password)
        {
            var usernameParam = new SqlParameter("@Username", username);
            var passwordParam = new SqlParameter("@Password", password);

            var result = await _context.UserLoginModel
           .FromSqlRaw("EXEC UserLogin @Username, @Password", usernameParam, passwordParam)
           .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
