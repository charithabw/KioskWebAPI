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
    public class ProductImageService : IProductImageService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public ProductImageService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetProductImageByProductNameID(int productNameID)
        {
            try
            {
                var pProductNameID = new SqlParameter { ParameterName = "@ProductNameID", SqlDbType = SqlDbType.Int, Value = productNameID, Direction = ParameterDirection.Input };
                var result = await _context.ProductImageGetModel
                .FromSqlRaw("EXEC GetProductImageByProductNameID @ProductNameID", pProductNameID)
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

        public async Task<KioskResponse> SaveProductImage(ProductImageSaveModel item)
        {
            int outputParam = 0;
            var pProductNameID = new SqlParameter("@ProductNameID", item.ProductNameID);
            var pLogo = new SqlParameter("@Logo", item.Logo ?? (object)DBNull.Value);
            var pQRAndroid = new SqlParameter("@QRAndroid", item.QRAndroid ?? (object)DBNull.Value);
            var pQRApple = new SqlParameter("@QRApple", item.QRApple ?? (object)DBNull.Value);
            var pQRHuawei = new SqlParameter("@QRHuawei", item.QRHuawei ?? (object)DBNull.Value);
            var pBackgroundImage = new SqlParameter("@BackgroundImage", item.BackgroundImage ?? (object)DBNull.Value);
            var pIsActive = new SqlParameter("@IsActive", item.IsActive);
            //var pCreatedDate = new SqlParameter("@CreatedDate", item.CreatedDate ?? (object)DBNull.Value);
            var pCreatedBy = new SqlParameter("@CreatedBy", item.CreatedBy ?? (object)DBNull.Value);
            var pOut = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC SaveProductImage @ProductNameID, @Logo, @QRAndroid, @QRApple, @QRHuawei, @BackgroundImage, @IsActive, @CreatedBy, @Result OUTPUT",
                    pProductNameID, pLogo, pQRAndroid, pQRApple, pQRHuawei, pBackgroundImage, pIsActive, pCreatedBy, pOut);
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

        public async Task<KioskResponse> UpdateProductImage(int productImageId, ProductImageUpdateModel item)
        {
            int outputParam = 0;
            var pProductImageID = new SqlParameter("@ProductImageID", productImageId);
            var pProductNameID = new SqlParameter("@ProductNameID", item.ProductNameID);
            var pLogo = new SqlParameter("@Logo", item.Logo ?? (object)DBNull.Value);
            var pQRAndroid = new SqlParameter("@QRAndroid", item.QRAndroid ?? (object)DBNull.Value);
            var pQRApple = new SqlParameter("@QRApple", item.QRApple ?? (object)DBNull.Value);
            var pQRHuawei = new SqlParameter("@QRHuawei", item.QRHuawei ?? (object)DBNull.Value);
            var pBackgroundImage = new SqlParameter("@BackgroundImage", item.BackgroundImage ?? (object)DBNull.Value);
            var pIsActive = new SqlParameter("@IsActive", item.IsActive);
            //var pModifiedDate = new SqlParameter("@ModifiedDate", item.ModifiedDate ?? (object)DBNull.Value);
            var pModifiedBy = new SqlParameter("@ModifiedBy", item.ModifiedBy ?? (object)DBNull.Value);
            var pOut = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdateProductImage @ProductImageID, @ProductNameID, @Logo, @QRAndroid, @QRApple, @QRHuawei, @BackgroundImage, @IsActive, @ModifiedBy, @Result OUTPUT",
                    pProductImageID, pProductNameID, pLogo, pQRAndroid, pQRApple, pQRHuawei, pBackgroundImage, pIsActive,pModifiedBy, pOut);
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
