CREATE PROCEDURE [dbo].[GetPromotional]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT PromotionalID, PromotionalName, PromotionalDesc, IsActive, ImagePath, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate
	FROM Promotional;
	

END