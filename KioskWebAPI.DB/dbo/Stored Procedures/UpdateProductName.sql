
CREATE PROCEDURE [dbo].[UpdateProductName]
	@ProductNameID int,
	@CategoryID int,
	@ProdEng varchar(50),	
	@ProdSin varchar(50),	
	@ProdTam varchar(50),
	@IsActive BIT = NULL,
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
		IsActive = @IsActive,
		ModifiedDate = GETDATE(),
		ModifiedBy = @ModifiedBy
	WHERE ProductNameID = @ProductNameID

	SET @Result = @@ROWCOUNT;
END