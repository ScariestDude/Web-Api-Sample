IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateEmployee]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[UpdateEmployee]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.UpdateEmployee
	@Id int, 
    @Name varchar(max),
    @Sex tinyint,
	@Birthday Datetime,
	@Location varchar(max),
	@Position varchar(max),
	@Email varchar(max),  
	@PhoneNumber varchar(max)
AS
BEGIN 
SET NOCOUNT ON
 
    UPDATE tblEmployees
	SET	
		Name = @Name, 
		Sex = @Sex, 
		Birthday = @Birthday, 
		Location = @Location, 
		Position = @Position, 
		Email = @Email, 
		PhoneNumber = @PhoneNumber
	WHERE Id = @Id

END