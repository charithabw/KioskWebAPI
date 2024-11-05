using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using static KioskWebAPI.Common.KioskEnums;

namespace KioskWebAPI.Services
{
    public class HomeScreenService : IHomeScreenService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public HomeScreenService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> SaveHomeScreen(HomeScreenSaveModel item)
        {
            int outputParam = 0;

            var pScrnHeading = new SqlParameter { ParameterName = "@ScrnHeading", SqlDbType = SqlDbType.VarChar, Value = item.ScrnHeading, Direction = ParameterDirection.Input };
            var pScrnBannerImg = new SqlParameter { ParameterName = "@ScrnBannerImg", SqlDbType = SqlDbType.VarBinary, Value = item.ScrnBannerImg, Direction = ParameterDirection.Input };
            var pScrnParagraph = new SqlParameter { ParameterName = "@ScrnParagraph", SqlDbType = SqlDbType.VarChar, Value = item.ScrnParagraph, Direction = ParameterDirection.Input };
            var pCreatedBy = new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = item.CreatedBy, Direction = ParameterDirection.Input };
            
            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveHomeScreen @ScrnHeading, @ScrnBannerImg, @ScrnParagraph, @CreatedBy, @Result OUTPUT", pScrnHeading, pScrnBannerImg, pScrnParagraph, pCreatedBy, pOut);
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

        public async Task<KioskResponse> GetHomeScreen()
        {
            try
            {
                var result = await _context.HomeScreenGetModel
                .FromSqlRaw("EXEC GetHomeScreen")
                .ToListAsync();

                return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), result);
            }
            catch(Exception e)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), null);
            }
            
        }
    }
}
