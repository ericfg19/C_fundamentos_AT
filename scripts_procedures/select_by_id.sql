USE [AgendaAmigosDB]
GO
/****** Object:  StoredProcedure [dbo].[SelectAmigoById]    Script Date: 28/06/2021 20:24:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SelectAmigoById]
	@IdSku int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Amigo
	WHERE AmigoId = @IdSku
END
