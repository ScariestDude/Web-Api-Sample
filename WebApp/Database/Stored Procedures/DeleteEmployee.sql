IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteEmployee]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[DeleteEmployee]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.DeleteEmployee 
    @Id int

AS
BEGIN 
SET NOCOUNT ON
 
    DELETE
	FROM tblEmployees
	WHERE Id = @Id

END