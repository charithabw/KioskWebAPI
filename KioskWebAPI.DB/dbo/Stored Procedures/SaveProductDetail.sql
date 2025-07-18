
CREATE PROCEDURE [dbo].[SaveProductDetail]
    @ProductNameID int,
    @TitleEng nvarchar(250), 
    @TitleSin nvarchar(250), 
    @TitleTam nvarchar(250), 
    @DesEng nvarchar(1000),  
    @DesSin nvarchar(1000),  
    @DesTam nvarchar(1000),  
    @SubTitleEng nvarchar(250), 
    @SubTitleSin nvarchar(250), 
    @SubTitleTam nvarchar(250), 
    @PointListEng nvarchar(1500),   
    @PointListSin nvarchar(1500),   
    @PointListTam nvarchar(1500),   
    @CreatedBy int,
    @Result INT OUTPUT
AS
BEGIN
    
    SET NOCOUNT ON;
    INSERT INTO ProductDetail(
        ProductNameID,
        TitleEng,
        TitleSin,
        TitleTam,
        DesEng,
        DesSin,
        DesTam,
        SubTitleEng,
        SubTitleSin,
        SubTitleTam,
        PointListEng,
        PointListSin,
        PointListTam,
        IsActive,
        CreatedDate,
        CreatedBy
    )VALUES (
        @ProductNameID,
        @TitleEng,
        @TitleSin,
        @TitleTam,
        @DesEng,
        @DesSin,
        @DesTam,
        @SubTitleEng,
        @SubTitleSin,
        @SubTitleTam,
        @PointListEng,
        @PointListSin,
        @PointListTam,
        1,
        GETDATE(),
        @CreatedBy
    )
    SEt @Result = @@ROWCOUNT; 

END