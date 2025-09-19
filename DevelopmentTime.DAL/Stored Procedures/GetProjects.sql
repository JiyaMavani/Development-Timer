CREATE PROCEDURE sp_GetProjectById
    @Id INT
AS
BEGIN
    SELECT * FROM Projects WHERE Id = @Id;
END
GO

CREATE PROCEDURE sp_GetProjectByName
    @Name NVARCHAR(50)  
AS
BEGIN
    SELECT * FROM Projects WHERE Name LIKE @Name + '%'
END
GO

CREATE PROCEDURE sp_GetProjectsByMaxHours
    @MaxHoursPerDay INT
AS
BEGIN
    SELECT * FROM Projects WHERE MaxHoursPerDay = @MaxHoursPerDay;
END
GO

CREATE PROCEDURE sp_GetProjectsByStatus
    @Status INT 
AS
BEGIN
    SELECT * FROM Projects WHERE Status = @Status;
END
GO

CREATE PROCEDURE sp_GetAllProjects
AS
BEGIN
    SELECT * FROM Projects;
END
GO