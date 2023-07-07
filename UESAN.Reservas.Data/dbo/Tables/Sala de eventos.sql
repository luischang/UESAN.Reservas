CREATE TABLE [dbo].[Sala de eventos] (
    [Id_SalaEvento]  INT             IDENTITY (1, 1) NOT NULL,
    [Descripcion]    NVARCHAR (250)  NULL,
    [Estado]         BIT             NULL,
    [Id_Tipo_Evento] INT             NULL,
    [Precio]         DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id_SalaEvento] ASC),
    CONSTRAINT [FK_Sala de eventos.Id_Tipo_Evento] FOREIGN KEY ([Id_Tipo_Evento]) REFERENCES [dbo].[Tipo_Sala_Evento] ([Id_Tipo_Evento])
);

