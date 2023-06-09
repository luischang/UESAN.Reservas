CREATE TABLE [dbo].[Habitacion] (
    [Id_Habitacion] INT             IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (100)   NULL,
    [Capacidad]     INT             NULL,
    [Estado]        BIT             NULL,
    [Id_TipoHabi]   INT             NULL,
    [Precio]        DECIMAL (10, 2) NULL,
    [Cant_Camas]    INT             NULL,
    PRIMARY KEY CLUSTERED ([Id_Habitacion] ASC),
    CONSTRAINT [FK_Habitacion.Id_TipoHabi] FOREIGN KEY ([Id_TipoHabi]) REFERENCES [dbo].[Tipo_Habitacion] ([Id_TipoHabi])
);

