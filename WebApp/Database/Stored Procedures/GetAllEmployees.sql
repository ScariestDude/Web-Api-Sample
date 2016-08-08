IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllEmployees]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[GetAllEmployees]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.GetAllEmployees 

AS
BEGIN 
SET NOCOUNT ON
 
    SELECT *
	FROM tblEmployees

END