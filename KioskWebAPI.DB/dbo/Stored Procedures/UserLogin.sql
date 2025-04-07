
CREATE PROCEDURE [dbo].[UserLogin]
    @Username NVARCHAR(50),
    @Password NVARCHAR(256)
AS
BEGIN
    DECLARE @StoredPasswordHash NVARCHAR(256);

    -- Retrieve stored password hash for the given username
    SELECT @StoredPasswordHash = PasswordHash
    FROM Users
    WHERE Username = @Username;

    -- Check if the provided password matches the stored hash
    IF @StoredPasswordHash IS NOT NULL AND @StoredPasswordHash = @Password
    BEGIN
        SELECT 'Success' AS Status, UserId, Username
        FROM Users
        WHERE Username = @Username;
    END
    ELSE
    BEGIN
        SELECT 'Failure' AS Status, 0 AS UserId, 'Null' AS Username;
    END
END;