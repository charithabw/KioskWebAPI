
CREATE PROCEDURE [dbo].[GetRole]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT [RoleID]
		  ,[RoleName]
		  ,[IsActive]
		  ,[CreatedDate]
	  FROM [dbo].[Role]
	WHERE IsActive = 1

END