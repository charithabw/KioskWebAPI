using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
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

        public async Task<KioskResponse> GetAllPermissions()
        {
            try
            {
                var result = await _context.PermissionGetModel
                    .FromSqlRaw("EXEC GetAllPermissions")
                    .ToListAsync();

                if (result.Count > 0)
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), result);
                else
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record", result);
            }
            catch (Exception e)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), e.Message, null);
            }
        }

        public async Task<KioskResponse> SavePermission(PermissionSaveModel item)
        {
            int outputParam = 0;
            var pPermissionName = new SqlParameter("@PermissionName", item.PermissionName ?? (object)DBNull.Value);
            var pPermissionCode = new SqlParameter("@PermissionCode", item.PermissionCode ?? (object)DBNull.Value);
            var pScreenID = new SqlParameter("@ScreenID", item.ScreenID);
            var pRoleID = new SqlParameter("@RoleID", item.RoleID);
            var pCanAdd = new SqlParameter("@CanAdd", item.CanAdd ?? (object)DBNull.Value);
            var pCanEdit = new SqlParameter("@CanEdit", item.CanEdit ?? (object)DBNull.Value);
            var pCanDelete = new SqlParameter("@CanDelete", item.CanDelete ?? (object)DBNull.Value);
            var pCanView = new SqlParameter("@CanView", item.CanView ?? (object)DBNull.Value);
            //var pIsActive = new SqlParameter("@IsActive", item.IsActive ?? (object)DBNull.Value);
            //var pCreatedDate = new SqlParameter("@CreatedDate", item.CreatedDate ?? (object)DBNull.Value);
            var pCreatedBy = new SqlParameter("@CreatedBy", item.CreatedBy ?? (object)DBNull.Value);
            var pOut = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC SavePermission @PermissionName, @PermissionCode, @ScreenID, @RoleID, @CanAdd, @CanEdit, @CanDelete, @CanView, @CreatedBy, @Result OUTPUT",
                    pPermissionName, pPermissionCode, pScreenID, pRoleID, pCanAdd, pCanEdit, pCanDelete, pCanView,  pCreatedBy, pOut);
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

        public async Task<KioskResponse> UpdatePermission(int permissionId, PermissionUpdateModel item)
        {
            int outputParam = 0;
            var pPermissionID = new SqlParameter("@PermissionID", permissionId);
            var pPermissionName = new SqlParameter("@PermissionName", item.PermissionName ?? (object)DBNull.Value);
            var pPermissionCode = new SqlParameter("@PermissionCode", item.PermissionCode ?? (object)DBNull.Value);
            var pScreenID = new SqlParameter("@ScreenID", item.ScreenID);
            var pRoleID = new SqlParameter("@RoleID", item.RoleID);
            var pCanAdd = new SqlParameter("@CanAdd", item.CanAdd ?? (object)DBNull.Value);
            var pCanEdit = new SqlParameter("@CanEdit", item.CanEdit ?? (object)DBNull.Value);
            var pCanDelete = new SqlParameter("@CanDelete", item.CanDelete ?? (object)DBNull.Value);
            var pCanView = new SqlParameter("@CanView", item.CanView ?? (object)DBNull.Value);
            var pIsActive = new SqlParameter("@IsActive", item.IsActive ?? (object)DBNull.Value);
            //var pModifiedDate = new SqlParameter("@ModifiedDate", item.ModifiedDate ?? (object)DBNull.Value);
            var pModifiedBy = new SqlParameter("@ModifiedBy", item.ModifiedBy ?? (object)DBNull.Value);
            var pOut = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdatePermission @PermissionID, @PermissionName, @PermissionCode, @ScreenID, @RoleID, @CanAdd, @CanEdit, @CanDelete, @CanView, @IsActive, @ModifiedBy, @Result OUTPUT",
                    pPermissionID, pPermissionName, pPermissionCode, pScreenID, pRoleID, pCanAdd, pCanEdit, pCanDelete, pCanView, pIsActive, pModifiedBy, pOut);
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
