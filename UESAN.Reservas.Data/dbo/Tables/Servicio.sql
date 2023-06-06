CREATE TABLE [dbo].[Servicio] (
    [Id_Servicio] INT             NOT NULL IDENTITY,
    [Descripcion] VARCHAR (100)   NULL,
    [Estado]      BIT             NULL,
    [Precio]      DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id_Servicio] ASC)
);

