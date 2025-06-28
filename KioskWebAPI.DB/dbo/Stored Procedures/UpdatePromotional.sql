CREATE PROCEDURE [dbo].[UpdatePromotional]
    @PromotionalId INT,
    @PromotionalName varchar(50),	
	@PromotionalDesc varchar(255),
	@IsActive BIT,	
	@ImagePath varchar(255),
	@Status varchar(50),
    @ModifiedBy INT,
	
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM Promotional WHERE PromotionalID = @PromotionalId)
    BEGIN
        UPDATE Promotional
        SET 
            PromotionalName = @PromotionalName,
            PromotionalDesc = @PromotionalDesc,
            IsActive = @IsActive,
			ImagePath = @ImagePath,
			Status = @Status,
			ModifiedBy = @ModifiedBy,
            ModifiedDate = GETDATE()
        WHERE PromotionalID = @PromotionalId;
        
        SET @Result = @@ROWCOUNT;
    END
    ELSE
    BEGIN
        SET @Result = 0;
    END
END