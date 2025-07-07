CREATE PROCEDURE UpdatePermission
    @PermissionID INT,
    @PermissionName NVARCHAR(50),
    @PermissionCode NVARCHAR(50),
    @ScreenID INT,
    @RoleID INT,
    @CanAdd BIT = NULL,
    @CanEdit BIT = NULL,
    @CanDelete BIT = NULL,
    @CanView BIT = NULL,
    @IsActive BIT = NULL,
    @ModifiedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Permission
    SET
        PermissionName = @PermissionName,
        PermissionCode = @PermissionCode,
        ScreenID = @ScreenID,
        RoleID = @RoleID,
        CanAdd = @CanAdd,
        CanEdit = @CanEdit,
        CanDelete = @CanDelete,
        CanView = @CanView,
        IsActive = @IsActive,
        ModifiedDate = GETDATE(),
        ModifiedBy = @ModifiedBy
    WHERE PermissionID = @PermissionID;

    SET @Result = @@ROWCOUNT;
END