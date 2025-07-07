CREATE PROCEDURE [dbo].[SavePermission]
    @PermissionName NVARCHAR(50),
    @PermissionCode NVARCHAR(50),
    @ScreenID INT,
    @RoleID INT,
    @CanAdd BIT = NULL,
    @CanEdit BIT = NULL,
    @CanDelete BIT = NULL,
    @CanView BIT = NULL,
    @CreatedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Permission
    (
        PermissionName, PermissionCode, ScreenID, RoleID,
        CanAdd, CanEdit, CanDelete, CanView, IsActive,
        CreatedDate, CreatedBy
    )
    VALUES
    (
        @PermissionName, @PermissionCode, @ScreenID, @RoleID,
        @CanAdd, @CanEdit, @CanDelete, @CanView, 1,
        GETDATE(), @CreatedBy
    );

    SET @Result = @@ROWCOUNT;
END