using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static KioskWebAPI.Common.KioskEnums;
using System.Data;

namespace Kiosk.WebAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public RoleService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetRole()
        {
            try
            {               
                var result = await _context.RoleGetModel
                .FromSqlRaw("EXEC GetRole")
                .ToListAsync();

                if (result.Count > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), result);
                }
                else
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record", result);
                }

            }
            catch (Exception e)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), e.Message, null);
            }

        }
    }
}
