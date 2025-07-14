using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using KioskWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static KioskWebAPI.Common.KioskEnums;

namespace Kiosk.WebAPI.Services
{
    public class ScreenService : IScreenService
    {

        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public ScreenService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetScreen()
        {
            try
            {
                var result = await _context.ScreenGetModel
                .FromSqlRaw("EXEC GetScreen")
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

        public async Task<KioskResponse> SaveScreen(ScreenSaveModel item)
        {
            int outputParam = 0;

            var pScreenCode = new SqlParameter { ParameterName = "@ScreenCode", SqlDbType = SqlDbType.NVarChar, Value = item.ScreenCode, Direction = ParameterDirection.Input };
            var pScreenName = new SqlParameter { ParameterName = "@ScreenName", SqlDbType = SqlDbType.NVarChar, Value = item.ScreenName, Direction = ParameterDirection.Input };
            var pCreatedBy = new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = item.CreatedBy, Direction = ParameterDirection.Input };


            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveScreen @ScreenCode,@ScreenName, @CreatedBy, @Result OUTPUT", pScreenCode, pScreenName, pCreatedBy, pOut);
                outputParam = (int)pOut.Value;

                if (outputParam > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), outputParam + " Record Added");
                }
                else
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record Adedd");
                }
            }
            catch (Exception ex)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), string.Empty, ex.Message);
            }
        }

        public async Task<KioskResponse> UpdateScreen(int screenId, ScreenUpdateModel item)
        {
            int outputParam = 0;

            var pScreenId = new SqlParameter { ParameterName = "@ScreenID", SqlDbType = SqlDbType.Int, Value = screenId, Direction = ParameterDirection.Input };
            var pScreenCode = new SqlParameter { ParameterName = "@ScreenCode", SqlDbType = SqlDbType.NVarChar, Value = item.ScreenCode, Direction = ParameterDirection.Input };
            var pScreenName = new SqlParameter { ParameterName = "@ScreenName", SqlDbType = SqlDbType.NVarChar, Value = item.ScreenName, Direction = ParameterDirection.Input };
            var pIsActive = new SqlParameter { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = item.IsActive ?? (object)DBNull.Value, Direction = ParameterDirection.Input };
            //var pCreatedDate = new SqlParameter { ParameterName = "@CreatedDate", SqlDbType = SqlDbType.DateTime, Value = item.CreatedDate ?? (object)DBNull.Value, Direction = ParameterDirection.Input };
            var pModifiedBy = new SqlParameter { ParameterName = "@ModifiedBy", SqlDbType = SqlDbType.Int, Value = item.ModifiedBy ?? (object)DBNull.Value, Direction = ParameterDirection.Input };
            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdateScreen @ScreenID, @ScreenCode, @ScreenName, @IsActive, @ModifiedBy, @Result OUTPUT",
                    pScreenId, pScreenCode, pScreenName, pIsActive,pModifiedBy, pOut);
                outputParam = (int)pOut.Value;

                if (outputParam > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), outputParam + " Record Updated");
                }
                else
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record Updated");
                }
            }
            catch (Exception ex)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), string.Empty, ex.Message);
            }
        }
    }
}
