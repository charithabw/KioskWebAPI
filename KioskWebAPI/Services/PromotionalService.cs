using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using KioskWebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static KioskWebAPI.Common.KioskEnums;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KioskWebAPI.Services
{
    public class PromotionalService : IPromotionalService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public PromotionalService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetPromotional()
        {
            try
            {
                var result = await _context.PromotionalGetModel
                .FromSqlRaw("EXEC GetPromotional")
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

        public async Task<KioskResponse> SavePromotional(PromotionalSaveModel item)
        {
            int outputParam = 0;

            var pPromotionalName = new SqlParameter { ParameterName = "@PromotionalName", SqlDbType = SqlDbType.NVarChar, Value = item.PromotionalName, Direction = ParameterDirection.Input };
            var pPromotionalDesc = new SqlParameter { ParameterName = "@PromotionalDesc", SqlDbType = SqlDbType.NVarChar, Value = item.PromotionalDesc, Direction = ParameterDirection.Input };
            var pImagePath = new SqlParameter { ParameterName = "@ImagePath", SqlDbType = SqlDbType.NVarChar, Value = item.ImagePath, Direction = ParameterDirection.Input };
            var pStatus = new SqlParameter { ParameterName = "@Status", SqlDbType = SqlDbType.NVarChar, Value = item.Status, Direction = ParameterDirection.Input };
            var pCreatedBy = new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = item.CreatedBy, Direction = ParameterDirection.Input };
           
            




            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };


            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SavePromotional @PromotionalName, @PromotionalDesc, @ImagePath, @CreatedBy, @Result OUTPUT", pPromotionalName, pPromotionalDesc, pImagePath, pCreatedBy, pOut);
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


        //update
        public async Task<KioskResponse> UpdatePromotional(int promotionalId, PromotionalUpdateModel item)
        {
            int outputParam = 0;

            var pPromotionalId = new SqlParameter { ParameterName = "@PromotionalId", SqlDbType = SqlDbType.Int, Value = promotionalId, Direction = ParameterDirection.Input };
            var pPromotionalName = new SqlParameter { ParameterName = "@PromotionalName", SqlDbType = SqlDbType.NVarChar, Value = item.PromotionalName, Direction = ParameterDirection.Input };
            var pPromotionalDesc = new SqlParameter { ParameterName = "@PromotionalDesc", SqlDbType = SqlDbType.NVarChar, Value = item.PromotionalDesc, Direction = ParameterDirection.Input };
            var pIsActive = new SqlParameter { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = item.IsActive, Direction = ParameterDirection.Input };
            var pImagePath = new SqlParameter { ParameterName = "@ImagePath", SqlDbType = SqlDbType.NVarChar, Value = item.ImagePath, Direction = ParameterDirection.Input };
            var pStatus = new SqlParameter { ParameterName = "@Status", SqlDbType = SqlDbType.NVarChar, Value = item.Status, Direction = ParameterDirection.Input };
            var pModifiedBy = new SqlParameter { ParameterName = "@ModifiedBy", SqlDbType = SqlDbType.Int, Value = item.ModifiedBy, Direction = ParameterDirection.Input };
            
            
            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdatePromotional @PromotionalId, @PromotionalName, @PromotionalDesc, @IsActive, @ImagePath, @Status, @ModifiedBy, @Result OUTPUT",
                    pPromotionalId, pPromotionalName, pPromotionalDesc, pIsActive, pImagePath, pStatus, pModifiedBy, pOut);

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
