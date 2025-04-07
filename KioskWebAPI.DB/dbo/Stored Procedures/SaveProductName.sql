
CREATE PROCEDURE [dbo].[SaveProductName]
	@CategoryID int,
	@ProdEng varchar(50),	
	@ProdSin varchar(50),	
	@ProdTam varchar(50),	
	@CreatedBy int,
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO ProductName(
		CategoryID,
		ProdEng,
		ProdSin,
		ProdTam,
		IsActive,
		CreatedDate,
		CreatedBy
	)VALUES (
		@CategoryID,
		@ProdEng,
		@ProdSin,
		@ProdTam,
		1,
		GETDATE(),
		@CreatedBy
	)
	SEt @Result = @@ROWCOUNT; 

END