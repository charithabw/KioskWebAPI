using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static KioskWebAPI.Common.KioskEnums;
using System.Data;
using Kiosk.WebAPI.Models;

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

        public async Task<KioskResponse> SaveRole(RoleSaveModel item)
        {
            int outputParam = 0;
            var pRoleName = new SqlParameter("@RoleName", item.RoleName ?? (object)DBNull.Value);
            var pIsActive = new SqlParameter("@IsActive", item.IsActive ?? (object)DBNull.Value);
            var pCreatedDate = new SqlParameter("@CreatedDate", item.CreatedDate ?? (object)DBNull.Value);
            var pCreatedBy = new SqlParameter("@CreatedBy", item.CreatedBy ?? (object)DBNull.Value);
            var pOut = new SqlParameter("@Result", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC SaveRole @RoleName, @IsActive, @CreatedDate, @CreatedBy, @Result OUTPUT",
                    pRoleName, pIsActive, pCreatedDate, pCreatedBy, pOut);
                outputParam = (int)pOut.Value;

                if (outputParam > 0)
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), outputParam + " Record Added");
                else
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record Added");
            }
            catch (Exception ex)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), string.Empty, ex.Message);
            }
        }

        public async Task<KioskResponse> UpdateRole(int roleId, RoleUpdateModel item)
        {
            int outputParam = 0;
            var pRoleId = new SqlParameter("@RoleID", roleId);
            var pRoleName = new SqlParameter("@RoleName", item.RoleName ?? (object)DBNull.Value);
            var pIsActive = new SqlParameter("@IsActive", item.IsActive ?? (object)DBNull.Value);
            var pCreatedDate = new SqlParameter("@CreatedDate", item.CreatedDate ?? (object)DBNull.Value);
            var pModifiedBy = new SqlParameter("@ModifiedBy", item.ModifiedBy ?? (object)DBNull.Value);
            var pOut = new SqlParameter("@Result", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdateRole @RoleID, @RoleName, @IsActive, @CreatedDate, @ModifiedBy, @Result OUTPUT",
                    pRoleId, pRoleName, pIsActive, pCreatedDate, pModifiedBy, pOut);
                outputParam = (int)pOut.Value;

                if (outputParam > 0)
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), outputParam + " Record Updated");
                else
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record Updated");
            }
            catch (Exception ex)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), string.Empty, ex.Message);
            }
        }
    }
}
