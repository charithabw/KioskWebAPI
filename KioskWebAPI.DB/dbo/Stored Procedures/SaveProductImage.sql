CREATE PROCEDURE SaveProductImage
    @ProductNameID INT,
    @Logo NVARCHAR(MAX) = NULL,
    @QRAndroid NVARCHAR(MAX) = NULL,
    @QRApple NVARCHAR(MAX) = NULL,
    @QRHuawei NVARCHAR(MAX) = NULL,
    @BackgroundImage NVARCHAR(MAX) = NULL,
    @CreatedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ProductImage
    (
        ProductNameID, Logo, QRAndroid, QRApple, QRHuawei, BackgroundImage,
        IsActive, CreatedDate, CreatedBy
    )
    VALUES
    (
        @ProductNameID, @Logo, @QRAndroid, @QRApple, @QRHuawei, @BackgroundImage,
        1, GETDATE(), @CreatedBy
    );

    SET @Result = @@ROWCOUNT;
END