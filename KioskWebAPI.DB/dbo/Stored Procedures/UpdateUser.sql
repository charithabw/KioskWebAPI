
CREATE PROCEDURE [dbo].[UpdateUser]
    @UserId INT,
    @Username NVARCHAR(50),
    @Email NVARCHAR(100),
    @RoleId INT,
    @IsLock BIT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- First, check if the new username or email is already taken by ANOTHER user.
    IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE (Username = @Username OR Email = @Email) AND UserId != @UserId)
    BEGIN
        -- If the details are not taken, perform the update.
        UPDATE dbo.Users
        SET
            Username = @Username,
            Email = @Email,
            RoleID = @RoleId, -- Matches your table's column name
            IsLock = @IsLock
        WHERE
            UserId = @UserId;

        SET @Result = @@ROWCOUNT; -- This will be 1 if the user was found and updated.
    END
    ELSE
    BEGIN
        -- If the username or email is already taken, return -1 to indicate the conflict.
        SET @Result = -1;
    END
END