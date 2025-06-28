
CREATE PROCEDURE [dbo].[GetCategory]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT CategoryID, CatEng, CatSin, CatTam, ImagePath, CreatedBy,ModifiedBy, IsActive
	FROM Category
	WHERE IsActive = 1;

END