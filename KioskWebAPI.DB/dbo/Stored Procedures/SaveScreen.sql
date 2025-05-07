
CREATE PROCEDURE [dbo].[SaveScreen]
	@ScreenCode varchar(50),	
	@ScreenName varchar(50),	
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO Screen(
		ScreenCode,
		ScreenName,		
		IsActive,
		CreatedDate		
	)VALUES (
		@ScreenCode,
		@ScreenName,		
		1,
		GETDATE()		
	)
	SEt @Result = @@ROWCOUNT; 

END