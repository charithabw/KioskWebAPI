CREATE PROCEDURE UpdateProductImage
    @ProductImageID INT,
    @ProductNameID INT,
    @Logo NVARCHAR(MAX) = NULL,
    @QRAndroid NVARCHAR(MAX) = NULL,
    @QRApple NVARCHAR(MAX) = NULL,
    @QRHuawei NVARCHAR(MAX) = NULL,
    @BackgroundImage NVARCHAR(MAX) = NULL,
    @IsActive BIT = NULL,
    @ModifiedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductImage
    SET
        ProductNameID = @ProductNameID,
        Logo = @Logo,
        QRAndroid = @QRAndroid,
        QRApple = @QRApple,
        QRHuawei = @QRHuawei,
        BackgroundImage = @BackgroundImage,
        IsActive = @IsActive,
        ModifiedDate = GETDATE(),
        ModifiedBy = @ModifiedBy
    WHERE ProductImageID = @ProductImageID;

    SET @Result = @@ROWCOUNT;
END