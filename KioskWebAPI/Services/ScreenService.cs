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
           
            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveScreen @ScreenCode,@ScreenName, @Result OUTPUT", pScreenCode, pScreenName, pOut);
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
    }
}
