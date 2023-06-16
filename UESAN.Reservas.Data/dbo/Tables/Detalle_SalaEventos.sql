CREATE TABLE [dbo].[Detalle_SalaEventos] (
    [Id_Reserva]    INT             NOT NULL,
    [Id_SalaEvento] INT             NOT NULL,
    [Fecha_Inicio]  DATE            NULL,
    [Fecha_Fin]     DATE            NULL,
    [SubTotal]      DECIMAL (10, 2) NULL,
    CONSTRAINT [FK_Detalle_SalaEventos.Id_Reserva] FOREIGN KEY ([Id_Reserva]) REFERENCES [dbo].[ReservasOrder] ([Id_Reserva]),
    CONSTRAINT [FK_Detalle_SalaEventos.Id_SalaEvento] FOREIGN KEY ([Id_SalaEvento]) REFERENCES [dbo].[Sala de eventos] ([Id_SalaEvento])
);

