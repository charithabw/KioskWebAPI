
CREATE PROCEDURE [dbo].[GetScreen]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT [ScreenID]
		  ,[ScreenCode]
		  ,[ScreenName]		 
	  FROM [dbo].[Screen]
	WHERE IsActive = 1

END