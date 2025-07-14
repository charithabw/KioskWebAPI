
CREATE PROCEDURE [dbo].[GetProductImageByProductNameID]
	@ProductNameID int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [ProductImageID]
		  ,[ProductNameID]
		  ,[Logo]
		  ,[QRAndroid]
		  ,[QRApple]
		  ,[QRHuawei]
		  ,[BackgroundImage]
		  ,[IsActive]
		  ,[CreatedDate]
		  ,[CreatedBy]
		  ,[ModifiedDate]
		  ,[ModifiedBy]
	FROM ProductImage
	WHERE ProductNameID = @ProductNameID AND IsActive = 1

END