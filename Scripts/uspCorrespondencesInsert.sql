CREATE PROCEDURE [dbo].[uspCorrespondencesInsert]
	@Type NVARCHAR(150)
	,@SenderId INT
	,@AddresseeId INT
	,@Subject NVARCHAR(80)
	,@Body NVARCHAR(MAX)
	,@UserId INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
		
		DECLARE @Consecutive NVARCHAR(10)		
		
		IF (ISNULL(@Type, '') = 'CI')
		BEGIN			
			select @Consecutive = 'CI' + RIGHT('00000000' + Ltrim(Rtrim((NEXT VALUE FOR consecutive_ci))),8)
		END
		ELSE
		BEGIN
			select @Consecutive = 'CE' + RIGHT('00000000' + Ltrim(Rtrim((NEXT VALUE FOR consecutive_ce))),8)
		END
				
		INSERT INTO [dbo].[Correspondences] (
			Consecutive
			,[Type]
			,SenderId
			,AddresseeId
			,[Subject]
			,Body
			,Ready
			,[Date]
			,UserId
		) VALUES (
			@Consecutive
			,@Type
			,@SenderId
			,@AddresseeId
			,@Subject
			,@Body
			,0
			,GETDATE()
			,@UserId
		)		

COMMIT TRANSACTION
			SELECT 'Success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
