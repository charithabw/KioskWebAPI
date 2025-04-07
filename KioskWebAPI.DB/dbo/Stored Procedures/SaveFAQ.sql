
CREATE PROCEDURE [dbo].[SaveFAQ]	
	@ProductID int,	
	@FAQ varchar(250),	
	@FAQSubPoint varchar(550),	
	@CreatedBy INT,	
	@Result INT OUTPUT
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO FAQ(		
		ProductID,
		FAQ,
		FAQSubPoint,
		CreatedBy,
		IsActive,
		CreatedDate
	)VALUES (		
		@ProductID,
		@FAQ,
		@FAQSubPoint,
		@CreatedBy,
		1,
		GETDATE()		
	)
	SEt @Result = @@ROWCOUNT; 

END