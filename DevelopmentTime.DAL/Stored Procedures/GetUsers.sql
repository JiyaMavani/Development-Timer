CREATE PROCEDURE sp_GetUserById
    @Id INT
AS
BEGIN
    SELECT * FROM Users WHERE Id = @Id;
END
GO

CREATE PROCEDURE sp_GetUserByName
    @Name NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Users WHERE Username LIKE @Name + '%';
END
GO

CREATE PROCEDURE sp_GetUsersByRole
    @Role INT
AS
BEGIN
    SELECT * FROM Users WHERE Role = @Role;
END
GO

CREATE PROCEDURE sp_GetUsersByAssignedProject
    @ProjectId INT
AS
BEGIN
    SELECT *
    FROM Users
    WHERE CHARINDEX(',' + CAST(@ProjectId AS VARCHAR(10)) + ',', ',' + AssignedProjectIds + ',') > 0
END
GO

CREATE PROCEDURE sp_GetAllUsers
AS
BEGIN
    SELECT * FROM Users;
END
GO
