CREATE TABLE [dbo].[ReservasOrder] (
    [Id_Reserva]    INT  IDENTITY (1, 1) NOT NULL,
    [Id_Usuario]    INT  NULL,
    [Fecha_Ini]     DATE NULL,
    [Fecha_Fin]     DATE NULL,
    [Id_EstadoRes]  INT  NULL,
    [Cant_Personas] INT  NULL,
    [Id_Ofertas]    INT  NULL,
    PRIMARY KEY CLUSTERED ([Id_Reserva] ASC),
    CONSTRAINT [FK_Reservas.Id_EstadoRes] FOREIGN KEY ([Id_EstadoRes]) REFERENCES [dbo].[Id_Estado_Reserva] ([Id_EstadoRes]),
    CONSTRAINT [FK_Reservas.Id_Ofertas] FOREIGN KEY ([Id_Ofertas]) REFERENCES [dbo].[Ofertas] ([Id_Ofertas]),
    CONSTRAINT [FK_Reservas.Id_Usuario] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[Usuario] ([Id_Usuario])
);

