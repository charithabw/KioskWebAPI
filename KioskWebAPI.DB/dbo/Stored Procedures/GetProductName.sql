
CREATE PROCEDURE [dbo].[GetProductName]
	@CategoryID int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT ProductNameID, ProdEng, ProdSin, ProdTam, IsActive, CreatedDate,CreatedBy,ModifiedDate,ModifiedBy
	FROM ProductName
	WHERE CategoryID = @CategoryID AND IsActive = 1

END