CREATE PROCEDURE UspgetCorrespondenceByID
	@Id INT
AS
	SELECT Id
		,Consecutive
		,Type
		,SenderId
		,AddresseeId
		,Subject
		,Body
		,Ready
		,Date
		,UserId
	FROM Correspondences
	WHERE Id = @Id
GO
