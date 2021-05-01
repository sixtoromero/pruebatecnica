CREATE PROCEDURE [dbo].[uspCorrespondencesDelete]
	@Id INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY
		DELETE FROM Correspondences
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
