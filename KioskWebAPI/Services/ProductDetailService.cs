﻿using Kiosk.WebAPI.Interfaces;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static KioskWebAPI.Common.KioskEnums;
using System.Data;

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
    }
}