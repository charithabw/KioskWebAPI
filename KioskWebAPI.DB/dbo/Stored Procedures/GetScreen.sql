
CREATE PROCEDURE [dbo].[GetScreen]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT [ScreenID]
		  ,[ScreenCode]
		  ,[ScreenName]	
		  ,[IsActive]
		  ,[CreatedDate]
		  ,[ModifiedBy]
		  ,[ModifiedDate]
		  ,[CreatedBy]
	  FROM [dbo].[Screen]
	WHERE IsActive = 1

END