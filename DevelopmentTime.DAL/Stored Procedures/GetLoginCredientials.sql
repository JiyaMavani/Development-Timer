CREATE PROCEDURE sp_GetLoginCredientials
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Users
    WHERE Username = @Username AND Password = @Password
END