CREATE TABLE [dbo].[Detalle_Reservas] (
    [Id_Reserva]    INT             NOT NULL,
    [Id_Habitacion] INT             NULL,
    [Subtotal]      DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id_Reserva] ASC),
    CONSTRAINT [FK_Detalle_Reservas.Id_Habitacion] FOREIGN KEY ([Id_Habitacion]) REFERENCES [dbo].[Habitacion] ([Id_Habitacion]),
    CONSTRAINT [FK_Detalle_Reservas.Id_Reserva] FOREIGN KEY ([Id_Reserva]) REFERENCES [dbo].[ReservasOrder] ([Id_Reserva]), 
    
);

