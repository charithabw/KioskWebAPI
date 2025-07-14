
CREATE PROCEDURE [dbo].[SaveProductDetail]
	@ProductNameID int,
	@TitleEng varchar(250),	
	@TitleSin varchar(250),	
	@TitleTam varchar(250),	
	@DesEng varchar(1000),	
	@DesSin varchar(1000),	
	@DesTam varchar(1000),	
	@SubTitleEng varchar(250),	
	@SubTitleSin varchar(250),	
	@SubTitleTam varchar(250),	
	@PointListEng varchar(1500),	
	@PointListSin varchar(1500),	
	@PointListTam varchar(1500),	
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