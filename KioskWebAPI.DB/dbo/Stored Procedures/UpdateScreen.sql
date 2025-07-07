CREATE PROCEDURE [dbo].[UpdateScreen]
    @ScreenID INT,
    @ScreenCode NVARCHAR(50),
    @ScreenName NVARCHAR(50),
    @IsActive BIT = NULL,
    @ModifiedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Screen
    SET
        ScreenCode = @ScreenCode,
        ScreenName = @ScreenName,
        IsActive = ISNULL(@IsActive, IsActive),
		ModifiedBy = @ModifiedBy,
        ModifiedDate = GETDATE()
    WHERE ScreenID = @ScreenID;

    SET @Result = @@ROWCOUNT;
END