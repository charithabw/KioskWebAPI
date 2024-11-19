
CREATE PROCEDURE [dbo].[GetCategory]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT CategoryID, CatEng, CatSin, CatTam
	FROM Category
	WHERE IsActive = 1

END