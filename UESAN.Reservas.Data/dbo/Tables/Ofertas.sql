CREATE TABLE [dbo].[Ofertas] (
    [Id_Ofertas]  INT             NOT NULL IDENTITY,
    [Descripcion] VARCHAR (100)   NULL,
    [Descuento]   DECIMAL (10, 2) NULL,
    [Fecha_Ini]   DATE            NULL,
    [Fecha_Fin]   DATE            NULL,
    [Estado]      BIT             NULL,
    PRIMARY KEY CLUSTERED ([Id_Ofertas] ASC)
);

