CREATE PROCEDURE sp_GetTaskItemById
    @Id INT
AS
BEGIN
    SELECT * FROM TaskItems WHERE Id = @Id;
END
GO

CREATE PROCEDURE sp_GetTaskItemsByTitle
    @Title NVARCHAR(200)
AS
BEGIN
    SELECT * FROM TaskItems WHERE Title LIKE @Title + '%';
END
GO

CREATE PROCEDURE sp_GetTaskItemsByDescription
    @Description NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM TaskItems WHERE Description LIKE @Description + '%'
END
GO

CREATE PROCEDURE sp_GetTaskItemsByDeveloperId
    @DeveloperId INT
AS
BEGIN
    SELECT * FROM TaskItems WHERE DeveloperId = @DeveloperId;
END
GO

CREATE PROCEDURE sp_GetTaskItemsByProjectId
    @ProjectId INT
AS
BEGIN
    SELECT * FROM TaskItems WHERE ProjectId = @ProjectId;
END
GO

CREATE PROCEDURE sp_GetTaskItemsByEstimatedHours
    @EstimatedHours INT
AS
BEGIN
    SELECT * FROM TaskItems WHERE EstimatedHours = @EstimatedHours;
END
GO

CREATE PROCEDURE sp_GetTaskItemsByStatus
    @Status INT
AS
BEGIN
    SELECT * FROM TaskItems WHERE Status = @Status;
END
GO

CREATE PROCEDURE sp_GetAllTaskItems
AS
BEGIN
    SELECT * FROM TaskItems;
END
GO

