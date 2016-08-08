IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmployee]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[GetEmployee]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.GetEmployee 
    @Id int

AS
BEGIN 
SET NOCOUNT ON
 
    SELECT *
	FROM tblEmployees
	WHERE Id = @Id

END