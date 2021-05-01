CREATE TRIGGER TR_LogCorrespondencesDelete
ON Correspondences
FOR DELETE
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
			'D',
			(SELECT * FROM inserted FOR JSON AUTO),
			GETDATE(),
			inserted.UserId
	FROM inserted
