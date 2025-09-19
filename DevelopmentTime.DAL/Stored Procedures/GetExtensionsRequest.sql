CREATE PROCEDURE sp_GetExtensionRequestById
    @Id INT
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE Id = @Id;
END
GO

CREATE PROCEDURE sp_GetExtensionRequestByTaskItemId
    @TaskItemId INT
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE TaskItemId = @TaskItemId;
END
GO

CREATE PROCEDURE sp_GetExtensionRequestByDeveloperId
    @DeveloperId INT
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE DeveloperId = @DeveloperId;
END
GO

CREATE PROCEDURE sp_GetExtensionRequestByExtraHours
    @ExtraHours INT
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE ExtraHours = @ExtraHours;
END
GO

CREATE PROCEDURE sp_GetExtensionRequestByJustification
    @Justification NVARCHAR(250)
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE Justification LIKE @Justification + '%';
END
GO

CREATE PROCEDURE sp_GetExtensionRequestByStatus
    @Status INT
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE Status = @Status;
END
GO

CREATE PROCEDURE sp_GetExtensionRequestByRequestDate
    @RequestDate DATE
AS
BEGIN
    SELECT * FROM ExtensionRequests WHERE RequestDate = @RequestDate;
END
GO

CREATE PROCEDURE sp_GetAllExtensionRequests
AS
BEGIN
    SELECT * FROM ExtensionRequests 
END
GO