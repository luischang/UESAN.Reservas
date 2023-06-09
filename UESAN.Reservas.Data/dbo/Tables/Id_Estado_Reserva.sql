CREATE TABLE [dbo].[Id_Estado_Reserva] (
    [Id_EstadoRes] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (50)  NULL,
    [Motivo]       VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id_EstadoRes] ASC)
);

