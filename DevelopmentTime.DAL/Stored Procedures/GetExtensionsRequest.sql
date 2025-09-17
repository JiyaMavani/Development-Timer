CREATE PROCEDURE GetExtensionsRequest
	@Id INT = NULL,
	@TaskItemId INT = NULL,
	@DeveloperId INT = NULL,
	@ExtraHours INT = NULL,
	@Justification NVARCHAR(250) = NULL,
	@Status INT = NULL,
	@RequestDate DATETIME2(7) = NULL

AS
BEGIN
	SELECT * 
	FROM ExtensionRequests
	WHERE (@Id IS NULL OR Id = @Id)
      AND (@TaskItemId IS NULL OR TaskItemId = @TaskItemId)
      AND (@DeveloperId IS NULL OR DeveloperId = @DeveloperId)
	  AND (@ExtraHours IS NULL OR ExtraHours = @ExtraHours)
      AND (@Status IS NULL OR Status = @Status)
	  AND (@Justification IS NULL OR Justification LIKE '%' + @Justification + '%')
      AND (@RequestDate IS NULL OR CAST(RequestDate AS DATE) = @RequestDate)

END
