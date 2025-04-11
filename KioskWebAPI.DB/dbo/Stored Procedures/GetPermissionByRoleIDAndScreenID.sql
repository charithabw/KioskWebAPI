
CREATE PROCEDURE [dbo].[GetPermissionByRoleIDAndScreenID]
	@RoleID int,
	@ScreenID int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT PermissionName, PermissionID, PermissionCode, CanView, CanAdd, CanEdit, CanDelete
	FROM Permission
	WHERE IsActive = 1 AND ScreenID = @ScreenID AND RoleID = @RoleID

END