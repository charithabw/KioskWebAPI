using Kiosk.WebAPI.Interfaces;
using Kiosk.WebAPI.Models;
using KioskWebAPI.Common;
using KioskWebAPI.DBContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static KioskWebAPI.Common.KioskEnums;

namespace Kiosk.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;
        private readonly IKioskResponse _response;

        public UserService(AppDBContext context, IKioskResponse response)
        {
            _context = context;
            _response = response;
        }

        public async Task<KioskResponse> GetUsers()
        {
            try
            {
                var result = await _context.UserGetModel
                .FromSqlRaw("EXEC GetAllUsers")
                .ToListAsync();

                if (result.Count > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), result);
                }
                else
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "No Records Found", result);
                }
            }
            catch (Exception e)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), e.Message, null);
            }
        }

       
public async Task<KioskResponse> SaveUser(UserSaveModel item)
{
    int outputParam = 0;
    var pUsername = new SqlParameter("@Username", item.Username);
    var pPassword = new SqlParameter("@Password", item.Password);
    var pEmail = new SqlParameter("@Email", item.Email);
    var pRoleId = new SqlParameter("@RoleId", item.RoleId);
    var pOut = new SqlParameter("@Result", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };

    try
    {
        await _context.Database.ExecuteSqlRawAsync(
            "EXEC SaveUser @Username, @Password, @Email, @RoleId, @Result OUTPUT",
            pUsername, pPassword, pEmail, pRoleId, pOut);
        outputParam = (int)pOut.Value;

        if (outputParam > 0)
        {
            return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), "User Added Successfully");
        }
        else
        {
            return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "Failed to add user.");
        }
    }
    catch (Exception ex)
    {
        if (ex.Message.Contains("UNIQUE KEY constraint"))
        {
            return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "Username or Email already exists.");
        }
        return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "An unexpected error occurred.", ex.Message);
    }
}

        public async Task<KioskResponse> UpdateUser(int userId, UserUpdateModel item)
        {
            int outputParam = 0;
            var pUserId = new SqlParameter("@UserId", userId);
            var pUsername = new SqlParameter("@Username", item.Username);
            var pEmail = new SqlParameter("@Email", item.Email);
            var pRoleId = new SqlParameter("@RoleId", item.RoleId);
            var pIsLock = new SqlParameter("@IsLock", item.IsLock);
            var pOut = new SqlParameter("@Result", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdateUser @UserId, @Username, @Email, @RoleId, @IsLock, @Result OUTPUT",
                    pUserId, pUsername, pEmail, pRoleId, pIsLock, pOut);
                outputParam = (int)pOut.Value;

                if (outputParam > 0)
                {
                    return _response.GenerateResponseMessage(statusCode.SUCCESS.ToString(), "User Updated Successfully");
                }
                else if (outputParam == -1)
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "Username or Email is already taken by another user.");
                }
                else
                {
                    return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "User not found or could not be updated.");
                }
            }
            catch (Exception ex)
            {
                return _response.GenerateResponseMessage(statusCode.ERROR.ToString(), "An unexpected error occurred.", ex.Message);
            }
        }


    }
}
