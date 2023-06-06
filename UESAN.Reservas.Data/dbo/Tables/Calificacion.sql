﻿CREATE TABLE [dbo].[Calificacion] (
    [Id_Calificacion] INT           NOT NULL IDENTITY,
    [Id_Reserva]      INT           NULL,
    [Num_Estrellas]   INT           NULL,
    [Recomendacion]   VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id_Calificacion] ASC),
    CONSTRAINT [FK_Calificacion.Id_Reserva] FOREIGN KEY ([Id_Reserva]) REFERENCES [dbo].[ReservasOrder] ([Id_Reserva])
);

