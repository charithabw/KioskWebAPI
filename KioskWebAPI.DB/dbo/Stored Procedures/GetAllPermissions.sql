CREATE PROCEDURE GetAllPermissions
AS
BEGIN
    SET NOCOUNT ON;
   	SELECT [PermissionID]
      ,[PermissionName]
      ,[PermissionCode]
      ,[ScreenID]
      ,[RoleID]
      ,[CanAdd]
      ,[CanEdit]
      ,[CanDelete]
      ,[CanView]
      ,[IsActive]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
	  FROM [dbo].[Permission]
	WHERE IsActive = 1
END