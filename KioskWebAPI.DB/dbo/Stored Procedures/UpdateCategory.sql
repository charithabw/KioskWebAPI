
CREATE PROCEDURE [dbo].[UpdateCategory]
    @CategoryId INT,
    @CatEng NVARCHAR(100),
    @CatSin NVARCHAR(100),
    @CatTam NVARCHAR(100),
    @ModifiedBy INT,
    @ImagePath NVARCHAR(255),
    @IsActive BIT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM Category WHERE CategoryId = @CategoryId)
    BEGIN
        UPDATE Category
        SET 
            CatEng = @CatEng,
            CatSin = @CatSin,
            CatTam = @CatTam,
            ImagePath = @ImagePath,
            IsActive = @IsActive,
            ModifiedBy = @ModifiedBy,
            ModifiedDate = GETDATE()
        WHERE CategoryId = @CategoryId;
        
        SET @Result = @@ROWCOUNT;
    END
    ELSE
    BEGIN
        SET @Result = 0;
    END
END