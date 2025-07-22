CREATE PROCEDURE [dbo].[SaveUser]
    @Username NVARCHAR(50),
    @Password NVARCHAR(255),
    @Email NVARCHAR(100),
    @RoleId INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Users (Username, PasswordHash, Email, RoleID, CreatedDate, IsLock, LockCount)
    VALUES (@Username, @Password, @Email, @RoleId, GETDATE(), 0, 0);

    SET @Result = @@ROWCOUNT;
END