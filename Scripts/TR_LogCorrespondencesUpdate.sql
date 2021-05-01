CREATE TRIGGER TR_LogCorrespondencesUpdate
ON Correspondences
FOR UPDATE
AS

	INSERT INTO AuditLogs (
			TableName
			,RegisterId
			,[Action]
			,[Data]
			,[Date]
			,UserId)
	SELECT 
			'Correspondences', 
			inserted.Consecutive, 
			'U', 
			(SELECT * FROM inserted FOR JSON AUTO),
			GETDATE(),
			inserted.UserId
	FROM inserted
