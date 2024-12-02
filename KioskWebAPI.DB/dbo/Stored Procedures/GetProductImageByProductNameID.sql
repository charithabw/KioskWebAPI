
CREATE PROCEDURE [dbo].[GetProductImageByProductNameID]
	@ProductNameID int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [ProductImageID]		  
		  ,[Logo]
		  ,[QRAndroid]
		  ,[QRApple]
		  ,[QRHuawei]
		  ,[BackgroundImage]		     
	FROM ProductImage
	WHERE ProductNameID = @ProductNameID AND IsActive = 1

END