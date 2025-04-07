
CREATE PROCEDURE [dbo].[SaveFeedback]	
	@EmojiID int,	
	@Feedback varchar(550),	
	@CusName varchar(50),	
	@CusPhone varchar(12),	
	@CusEmail varchar(50),	
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO Feedback(		
		EmojiID,
		Feedback,
		CusName,
		CusPhone,
		CusEmail,
		CreatedDate
	)VALUES (		
		@EmojiID,
		@Feedback,		
		@CusName,		
		@CusPhone,		
		@CusEmail,		
		GETDATE()		
	)
	SEt @Result = @@ROWCOUNT; 

END