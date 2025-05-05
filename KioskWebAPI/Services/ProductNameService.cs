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
    public class ProductNameService : IProductNameService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public ProductNameService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetProductName(int CategoryID)
        {
            try
            {
                var pCategoryID = new SqlParameter { ParameterName = "@CategoryID", SqlDbType = SqlDbType.Int, Value = CategoryID, Direction = ParameterDirection.Input };
                var result = await _context.ProductNameGetModel
                .FromSqlRaw("EXEC GetProductName @CategoryID", pCategoryID)
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

        public async Task<KioskResponse> SaveProductName(ProductNameSaveModel item)
        {
            int outputParam = 0;

            var pCategoryID = new SqlParameter { ParameterName = "@CategoryID", SqlDbType = SqlDbType.Int, Value = item.CategoryID, Direction = ParameterDirection.Input };
            var pProdEng = new SqlParameter { ParameterName = "@ProdEng", SqlDbType = SqlDbType.NVarChar, Value = item.ProdEng, Direction = ParameterDirection.Input };
            var pProdSin = new SqlParameter { ParameterName = "@ProdSin", SqlDbType = SqlDbType.NVarChar, Value = item.ProdSin, Direction = ParameterDirection.Input };
            var pProdTam = new SqlParameter { ParameterName = "@ProdTam", SqlDbType = SqlDbType.NVarChar, Value = item.ProdTam, Direction = ParameterDirection.Input };
            var pCreatedBy = new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = item.CreatedBy, Direction = ParameterDirection.Input };

            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveProductName @CategoryID, @ProdEng,@ProdSin, @ProdTam, @CreatedBy, @Result OUTPUT", pCategoryID,  pProdEng, pProdSin, pProdTam, pCreatedBy, pOut);
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

        public async Task<KioskResponse> UpdateProductName(ProductNameUpdateModel item)
        {
            int outputParam = 0;

            var pProductNameID = new SqlParameter { ParameterName = "@ProductNameID", SqlDbType = SqlDbType.Int, Value = item.ProductNameID, Direction = ParameterDirection.Input };
            var pCategoryID = new SqlParameter { ParameterName = "@CategoryID", SqlDbType = SqlDbType.Int, Value = item.CategoryID, Direction = ParameterDirection.Input };            
            var pProdEng = new SqlParameter { ParameterName = "@ProdEng", SqlDbType = SqlDbType.NVarChar, Value = item.ProdEng, Direction = ParameterDirection.Input };
            var pProdSin = new SqlParameter { ParameterName = "@ProdSin", SqlDbType = SqlDbType.NVarChar, Value = item.ProdSin, Direction = ParameterDirection.Input };
            var pProdTam = new SqlParameter { ParameterName = "@ProdTam", SqlDbType = SqlDbType.NVarChar, Value = item.ProdTam, Direction = ParameterDirection.Input };
            var pModifiedBy = new SqlParameter { ParameterName = "@ModifiedBy", SqlDbType = SqlDbType.Int, Value = item.ModifiedBy, Direction = ParameterDirection.Input };

            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdateProductName @ProductNameID, @CategoryID, @ProdEng, @ProdSin, @ProdTam, @ModifiedBy, @Result OUTPUT", pProductNameID, pCategoryID, pProdEng, pProdSin, pProdTam, pModifiedBy, pOut);
                outputParam = (int)pOut.Value;

                if (outputParam > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), outputParam + " Record Added");
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
