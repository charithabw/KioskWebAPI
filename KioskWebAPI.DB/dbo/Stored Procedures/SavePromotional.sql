CREATE PROCEDURE [dbo].[SavePromotional]
	@PromotionalName varchar(50),	
	@PromotionalDesc varchar(255),	
	@ImagePath varchar(255),
	@CreatedBy int,
	
	
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO Promotional(
		PromotionalName,
		PromotionalDesc,
		IsActive,
		ImagePath,
		CreatedBy,
		CreatedDate
	)VALUES (
		@PromotionalName,
		@PromotionalDesc,
		1,
		@ImagePath,
		@CreatedBy,
		GETDATE()
		
	)
	SEt @Result = @@ROWCOUNT; 

END