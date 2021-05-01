CREATE PROCEDURE UspgetCorrespondenceByID
	@Id INT
AS
	SELECT Id
		,Consecutive
		,Type
		,SenderId
		,(SELECT u.Names + ' ' + u.Surnames  FROM Users u WHERE u.Id = SenderId) AS Sender
		,AddresseeId
		,(SELECT u.Names + ' ' + u.Surnames  FROM Users u WHERE u.Id = AddresseeId) AS Addressee
		,Subject
		,Body
		,Ready
		,Date
		,UserId
	FROM Correspondences
	WHERE Id = @Id
GO
