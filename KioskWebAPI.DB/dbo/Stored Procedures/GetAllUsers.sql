CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SET NOCOUNT ON;

    -- This is the corrected query to prevent duplicates, formatted in your preferred style.
    SELECT
        [dbo].[Users].[UserId] AS [UserID],
        [dbo].[Users].[Username],
        [dbo].[Users].[Email],
        [dbo].[Users].[IsLock],
        [dbo].[Users].[CreatedDate],
        [dbo].[Role].[RoleName]
    FROM
        [dbo].[Users]
    LEFT JOIN
        [dbo].[Role] ON [dbo].[Users].[RoleID] = [dbo].[Role].[RoleID];
END