
CREATE PROCEDURE [dbo].[SaveScreen]
	@ScreenCode varchar(50),	
	@ScreenName varchar(50),
	@CreatedBy INT = NULL,
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO Screen(
		ScreenCode,
		ScreenName,		
		IsActive,
		CreatedDate,
		CreatedBy
	)VALUES (
		@ScreenCode,
		@ScreenName,		
		1,
		GETDATE(),
		@CreatedBy
	)
	SEt @Result = @@ROWCOUNT; 

END