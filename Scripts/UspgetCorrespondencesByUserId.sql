CREATE PROCEDURE UspgetCorrespondencesByUserId
	@UserId INT
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
	WHERE UserId = @UserId


