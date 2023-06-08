CREATE TABLE [dbo].[Detalle_Servicios] (
    [Id_Reserva]  INT             NOT NULL,
    [Id_Servicio] INT             NULL,
    [SubTotal]    DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id_Reserva] ASC),
    CONSTRAINT [FK_Detalle_Servicios.Id_Reserva] FOREIGN KEY ([Id_Reserva]) REFERENCES [dbo].[ReservasOrder] ([Id_Reserva]),
    CONSTRAINT [FK_Detalle_Servicios.Id_Servicio] FOREIGN KEY ([Id_Servicio]) REFERENCES [dbo].[Servicio] ([Id_Servicio])
);

