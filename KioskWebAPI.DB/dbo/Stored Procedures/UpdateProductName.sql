
CREATE PROCEDURE [dbo].[UpdateProductName]
	@ProductNameID int,
	@CategoryID int,
	@ProdEng varchar(50),	
	@ProdSin varchar(50),	
	@ProdTam varchar(50),	
	@ModifiedBy int,
	@Result INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ProductName
	SET 
		CategoryID = @CategoryID,
		ProdEng = @ProdEng,
		ProdSin = @ProdSin,
		ProdTam = @ProdTam,
		ModifiedDate = GETDATE(),
		ModifiedBy = @ModifiedBy
	WHERE ProductNameID = @ProductNameID

	SET @Result = @@ROWCOUNT;
END