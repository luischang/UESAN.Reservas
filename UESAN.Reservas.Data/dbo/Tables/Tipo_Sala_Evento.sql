CREATE TABLE [dbo].[Tipo_Sala_Evento] (
    [Id_Tipo_Evento] INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]    NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([Id_Tipo_Evento] ASC)
);

