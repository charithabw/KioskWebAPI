
CREATE PROCEDURE [dbo].[UpdateProductDetail]
    @ProductDetailID INT,
    @ProductNameID INT,
    @TitleEng NVARCHAR(250),
    @TitleSin NVARCHAR(250),
    @TitleTam NVARCHAR(250),
    @DesEng NVARCHAR(MAX),
    @DesSin NVARCHAR(MAX),
    @DesTam NVARCHAR(MAX),
    @SubTitleEng NVARCHAR(250),
    @SubTitleSin NVARCHAR(250),
    @SubTitleTam NVARCHAR(250),
    @PointListEng NVARCHAR(MAX),
    @PointListSin NVARCHAR(MAX),
    @PointListTam NVARCHAR(MAX),
    @IsActive BIT,
    @ModifiedBy INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM ProductDetail WHERE ProductDetailID = @ProductDetailID)
    BEGIN
        UPDATE ProductDetail
        SET
            ProductNameID = @ProductNameID,
            TitleEng = @TitleEng,
            TitleSin = @TitleSin,
            TitleTam = @TitleTam,
            DesEng = @DesEng,
            DesSin = @DesSin,
            DesTam = @DesTam,
            SubTitleEng = @SubTitleEng,
            SubTitleSin = @SubTitleSin,
            SubTitleTam = @SubTitleTam,
            PointListEng = @PointListEng,
            PointListSin = @PointListSin,
            PointListTam = @PointListTam,
            IsActive = @IsActive,
            ModifiedDate = GETDATE(),
            ModifiedBy = @ModifiedBy
        WHERE ProductDetailID = @ProductDetailID;

        SET @Result = @@ROWCOUNT;
    END
    ELSE
    BEGIN
        SET @Result = 0;
    END
END