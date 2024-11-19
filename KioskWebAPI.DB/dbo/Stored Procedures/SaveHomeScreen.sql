
CREATE PROCEDURE SaveHomeScreen 
	@ScrnHeading varchar(50),
	@ScrnBannerImg varbinary(50),
	@ScrnParagraph varchar(1500),
	@CreatedBy int,
	@Result INT OUTPUT

AS
BEGIN

	SET NOCOUNT ON;
	INSERT INTO scrn.HomeScreen (
		ScrnHeading,
		ScrnBannerImg,
		ScrnParagraph,
		IsActive,
		CreatedDate,
		CreatedBy
	)VALUES (
		@ScrnHeading,
		@ScrnBannerImg,
		@ScrnParagraph,
		1,
		GETDATE(),
		@CreatedBy
	)
	SEt @Result = @@ROWCOUNT; 
END