
CREATE PROCEDURE [dbo].[GetProductDetailByProductNameID]
	@ProductNameID int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [ProductDetailID]      
		  ,[TitleEng]
		  ,[TitleSin]
		  ,[TitleTam]
		  ,[DesEng]
		  ,[DesSin]
		  ,[DesTam]
		  ,[SubTitleEng]
		  ,[SubTitleSin]
		  ,[SubTitleTam]
		  ,[PointListEng]
		  ,[PointListSin]
		  ,[PointListTam]
		  ,[IsActive]
		  ,[CreatedBy]
		  ,[CreatedDate]
		  ,[ModifiedBy]
		  ,[ModifiedDate]
	FROM ProductDetail
	WHERE ProductNameID = @ProductNameID AND IsActive = 1

END