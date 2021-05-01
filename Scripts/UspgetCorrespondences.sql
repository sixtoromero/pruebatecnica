CREATE PROCEDURE UspgetCorrespondences
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
GO
