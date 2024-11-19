
CREATE PROCEDURE [dbo].[SaveCategory]
	@CatEng varchar(50),	
	@CatSin varchar(50),	
	@CatTam varchar(50),	
	@CreatedBy int,
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO Category(
		CatEng,
		CatSin,
		CatTam,
		IsActive,
		CreatedDate,
		CreatedBy
	)VALUES (
		@CatEng,
		@CatSin,
		@CatTam,
		1,
		GETDATE(),
		@CreatedBy
	)
	SEt @Result = @@ROWCOUNT; 

END