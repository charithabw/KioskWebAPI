using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static KioskWebAPI.Common.KioskEnums;
using System.Data;

namespace Kiosk.WebAPI.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public FeedbackService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }
        public async Task<KioskResponse> SaveFeedback(FeedbackSaveModel item)
        {
            int outputParam = 0;

            var pEmojiID = new SqlParameter { ParameterName = "@EmojiID", SqlDbType = SqlDbType.Int, Value = item.EmojiID, Direction = ParameterDirection.Input };
            var pScreenID = new SqlParameter { ParameterName = "@ScreenID", SqlDbType = SqlDbType.Int, Value = item.ScreenID, Direction = ParameterDirection.Input };
            var pFeedback = new SqlParameter { ParameterName = "@Feedback", SqlDbType = SqlDbType.NVarChar, Value = item.Feedback, Direction = ParameterDirection.Input };
            var pCusName = new SqlParameter { ParameterName = "@CusName", SqlDbType = SqlDbType.NVarChar, Value = item.CusName, Direction = ParameterDirection.Input };
            var pCusPhone = new SqlParameter { ParameterName = "@CusPhone", SqlDbType = SqlDbType.NVarChar, Value = item.CusPhone, Direction = ParameterDirection.Input };
            var pCusEmail = new SqlParameter { ParameterName = "@CusEmail", SqlDbType = SqlDbType.NVarChar, Value = item.CusEmail, Direction = ParameterDirection.Input };
            
            var pOut = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC SaveFeedback @EmojiID, @ScreenID, @Feedback, @CusName, @CusPhone, @CusEmail, @Result OUTPUT",
                    pEmojiID, pScreenID, pFeedback, pCusName, pCusPhone, pCusEmail, pOut);
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
