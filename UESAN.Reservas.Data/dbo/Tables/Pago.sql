CREATE TABLE [dbo].[Pago] (
    [Id_Pago]    INT             NOT NULL,
    [Id_Reserva] INT             NULL,
    [MetodoPago] INT             NULL,
    [MontoTotal] DECIMAL (10, 2) NULL,
    [Estado]     INT             NULL,
    PRIMARY KEY CLUSTERED ([Id_Pago] ASC),
    CONSTRAINT [FK_Pago.Id_Reserva] FOREIGN KEY ([Id_Reserva]) REFERENCES [dbo].[Reservas] ([Id_Reserva])
);

