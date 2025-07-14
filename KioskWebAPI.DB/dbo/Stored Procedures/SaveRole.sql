CREATE PROCEDURE [dbo].[SaveRole]
    @RoleName NVARCHAR(50),
   
    @CreatedBy INT = NULL,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Role (RoleName, CreatedDate, IsActive, CreatedBy)
    VALUES (@RoleName, GETDATE(),1, @CreatedBy);

    SET @Result = @@ROWCOUNT;
END