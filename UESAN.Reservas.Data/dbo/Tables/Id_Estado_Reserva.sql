CREATE TABLE [dbo].[Id_Estado_Reserva] (
    [Id_EstadoRes] INT           NOT NULL IDENTITY,
    [Nombre]       VARCHAR (50)  NULL,
    [Motivo]       VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id_EstadoRes] ASC)
);

