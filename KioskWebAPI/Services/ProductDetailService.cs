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
    public class ProductDetailService : IProductDetailService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public ProductDetailService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }
        public async Task<KioskResponse> GetProductDetailByProductNameID(int productNameID)
        {
            try
            {
                var pProductNameID = new SqlParameter { ParameterName = "@ProductNameID", SqlDbType = SqlDbType.Int, Value = productNameID, Direction = ParameterDirection.Input };
                var result = await _context.ProductDetailGetModel
                .FromSqlRaw("EXEC GetProductDetailByProductNameID @ProductNameID", pProductNameID)
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

        public async Task<KioskResponse> SaveProductDetail(ProductDetailSaveModel item)
        {
            int outputParam = 0;

            var pProductNameID = new SqlParameter { ParameterName = "@ProductNameID", SqlDbType = SqlDbType.Int, Value = item.ProductNameID, Direction = ParameterDirection.Input };
            var pTitleEng = new SqlParameter { ParameterName = "@TitleEng", SqlDbType = SqlDbType.NVarChar, Value = item.TitleEng, Direction = ParameterDirection.Input };
            var pTitleSin = new SqlParameter { ParameterName = "@TitleSin", SqlDbType = SqlDbType.NVarChar, Value = item.TitleSin, Direction = ParameterDirection.Input };
            var pTitleTam = new SqlParameter { ParameterName = "@TitleTam", SqlDbType = SqlDbType.NVarChar, Value = item.TitleTam, Direction = ParameterDirection.Input };
            var pDesEng = new SqlParameter { ParameterName = "@DesEng", SqlDbType = SqlDbType.NVarChar, Value = item.DesEng, Direction = ParameterDirection.Input };
            var pDesSin = new SqlParameter { ParameterName = "@DesSin", SqlDbType = SqlDbType.NVarChar, Value = item.DesSin, Direction = ParameterDirection.Input };
            var pDesTam = new SqlParameter { ParameterName = "@DesTam", SqlDbType = SqlDbType.NVarChar, Value = item.DesTam, Direction = ParameterDirection.Input };
            var pSubTitleEng = new SqlParameter { ParameterName = "@SubTitleEng", SqlDbType = SqlDbType.NVarChar, Value = item.SubTitleEng, Direction = ParameterDirection.Input };
            var pSubTitleSin = new SqlParameter { ParameterName = "@SubTitleSin", SqlDbType = SqlDbType.NVarChar, Value = item.SubTitleSin, Direction = ParameterDirection.Input };
            var pSubTitleTam = new SqlParameter { ParameterName = "@SubTitleTam", SqlDbType = SqlDbType.NVarChar, Value = item.SubTitleTam, Direction = ParameterDirection.Input };
            var pPointListEng = new SqlParameter { ParameterName = "@PointListEng", SqlDbType = SqlDbType.NVarChar, Value = item.PointListEng, Direction = ParameterDirection.Input };
            var pPointListSin = new SqlParameter { ParameterName = "@PointListSin", SqlDbType = SqlDbType.NVarChar, Value = item.PointListSin, Direction = ParameterDirection.Input };
            var pPointListTam = new SqlParameter { ParameterName = "@PointListTam", SqlDbType = SqlDbType.NVarChar, Value = item.PointListTam, Direction = ParameterDirection.Input };
            var pCreatedBy = new SqlParameter { ParameterName = "@CreatedBy", SqlDbType = SqlDbType.Int, Value = item.CreatedBy, Direction = ParameterDirection.Input };

            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveProductDetail @ProductNameID, @TitleEng, @TitleSin,@TitleTam, @DesEng, @DesSin, @DesTam, @SubTitleEng, @SubTitleSin, @SubTitleTam, @PointListEng, @PointListSin, @PointListTam, @CreatedBy, @Result OUTPUT",
                    pProductNameID, pTitleEng, pTitleSin, pTitleTam, pDesEng, pDesSin, pDesTam, pSubTitleEng, pSubTitleSin, pSubTitleTam,
                    pPointListEng, pPointListSin, pPointListTam, pCreatedBy, pOut);
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
