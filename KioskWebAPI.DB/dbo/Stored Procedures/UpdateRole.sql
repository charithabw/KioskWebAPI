CREATE PROCEDURE [dbo].[UpdateRole]
    @RoleID INT,
    @RoleName NVARCHAR(50),
    @IsActive BIT = NULL,
    @ModifiedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Role
    SET
        RoleName = @RoleName,
        IsActive = ISNULL(@IsActive, IsActive),
		ModifiedBy = @ModifiedBy,
        ModifiedDate = GETDATE()
        
    WHERE RoleID = @RoleID;

    SET @Result = @@ROWCOUNT;
END