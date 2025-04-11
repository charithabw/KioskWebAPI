using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static KioskWebAPI.Common.KioskEnums;

namespace Kiosk.WebAPI.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public PermissionService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetPermissionByRoleIDAndScreenID(int roleID, int screenID)
        {
            var pRoleID = new SqlParameter { ParameterName = "@RoleID", SqlDbType = SqlDbType.Int, Value = roleID, Direction = ParameterDirection.Input };
            var pScreenID = new SqlParameter { ParameterName = "@ScreenID", SqlDbType = SqlDbType.Int, Value = screenID, Direction = ParameterDirection.Input };
           
            try
            {
                var result = await _context.PermissionGetModel
                .FromSqlRaw("EXEC GetPermissionByRoleIDAndScreenID @RoleID, @ScreenID", pRoleID, pScreenID)
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
