CREATE TABLE [dbo].[Recaudo]
(
	[Nit] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [Mes] NVARCHAR(10) NULL, 
    [Año] NVARCHAR(10) NULL, 
    [Tipo] NVARCHAR(10) NULL, 
    [Valor] DECIMAL NULL, 
    [Identificacion] NVARCHAR(10) NULL, 
    [Nombre] NVARCHAR(10) NULL
)
