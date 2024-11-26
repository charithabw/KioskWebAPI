using Kiosk.WebAPI.Interfaces;
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
    }
}
