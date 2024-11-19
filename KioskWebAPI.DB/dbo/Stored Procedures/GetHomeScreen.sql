
CREATE PROCEDURE GetHomeScreen
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT RecordID, ScrnHeading, ScrnBannerImg, ScrnParagraph
	FROM SCRN.HomeScreen
	WHERE IsActive = 1

END