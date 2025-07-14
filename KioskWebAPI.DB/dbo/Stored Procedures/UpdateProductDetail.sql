CREATE PROCEDURE UpdateProductDetail
    @ProductDetailID INT,
    @ProductNameID INT,
    @TitleEng NVARCHAR(250) = NULL,
    @TitleSin NVARCHAR(250) = NULL,
    @TitleTam NVARCHAR(250) = NULL,
    @DesEng NVARCHAR(MAX) = NULL,
    @DesSin NVARCHAR(MAX) = NULL,
    @DesTam NVARCHAR(MAX) = NULL,
    @SubTitleEng NVARCHAR(250) = NULL,
    @SubTitleSin NVARCHAR(250) = NULL,
    @SubTitleTam NVARCHAR(250) = NULL,
    @PointListEng NVARCHAR(MAX) = NULL,
    @PointListSin NVARCHAR(MAX) = NULL,
    @PointListTam NVARCHAR(MAX) = NULL,
    @IsActive BIT = NULL,
    @ModifiedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

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