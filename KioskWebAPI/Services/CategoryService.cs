using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static KioskWebAPI.Common.KioskEnums;

namespace KioskWebAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public CategoryService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetCategory()
        {
            try
            {
                var result = await _context.CategoryGetModel
                .FromSqlRaw("EXEC GetCategory")
                .ToListAsync();

                if(result.Count > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), result);
                }
                else
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Record",  result);
                }
                
            }
            catch (Exception e)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), e.Message, null);
            }

        }

        public async Task<KioskResponse> SaveCategory(CategorySaveModel item)
        {
            int outputParam = 0;

            var pCatEng = new SqlParameter { ParameterName = "@CatEng", SqlDbType = SqlDbType.NVarChar, Value = item.CatEng, Direction = ParameterDirection.Input };            
            var pCatSin = new SqlParameter { ParameterName = "@CatSin", SqlDbType = SqlDbType.NVarChar, Value = item.CatSin, Direction = ParameterDirection.Input };            
            var pCatTam = new SqlParameter { ParameterName = "@CatTam", SqlDbType = SqlDbType.NVarChar, Value = item.CatTam, Direction = ParameterDirection.Input };            
            var pCreatedBy = new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = item.CreatedBy, Direction = ParameterDirection.Input };

            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveCategory @CatEng,@CatSin, @CatTam, @CreatedBy, @Result OUTPUT", pCatEng, pCatSin, pCatTam,  pCreatedBy, pOut);
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
