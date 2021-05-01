CREATE PROCEDURE [dbo].[uspCorrespondencesUpdate]
	@Id INT
	,@Type NVARCHAR(150)
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
				
		UPDATE [dbo].[Correspondences] 
		SET [Type] = @Type, SenderId = @SenderId, AddresseeId = @AddresseeId, [Subject] = @Subject, Body = @Body			
		WHERE Id = @Id		

COMMIT TRANSACTION
			SELECT 'Success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
