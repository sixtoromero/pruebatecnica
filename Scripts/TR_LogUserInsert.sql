CREATE TRIGGER [dbo].[TR_LogUserInsert]
ON [dbo].[Users]
FOR INSERT
AS
	INSERT INTO AuditLogs (
			TableName
			,RegisterId
			,[Action]
			,[Data]
			,[Date]
			,UserId)
	SELECT 
			'Users', 
			Cast(inserted.Id AS NVARCHAR(10)), 
			'I', 
			(SELECT * FROM inserted FOR JSON AUTO),
			GETDATE(),
			inserted.Id
	FROM inserted
