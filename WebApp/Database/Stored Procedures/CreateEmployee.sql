IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreateEmployee]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[CreateEmployee]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.CreateEmployee 
    @Name varchar(max),
    @Sex tinyint,
	@Birthday Datetime = null,
	@Location varchar(max) = null,
	@Position varchar(max) = null,
	@Email varchar(max) = null,  
	@PhoneNumber varchar(max) = null
AS
BEGIN 
SET NOCOUNT ON
 
    INSERT INTO tblEmployees
		(Name, Sex, Birthday, Location, Position, Email, PhoneNumber)
	VALUES
		(@Name, @Sex, @Birthday, @Location, @Position, @Email, @PhoneNumber)
END