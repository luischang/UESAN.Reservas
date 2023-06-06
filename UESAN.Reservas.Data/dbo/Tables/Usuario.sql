CREATE TABLE [dbo].[Usuario] (
    [Id_Usuario] INT           NOT NULL IDENTITY,
    [Email]      VARCHAR (100) NULL,
    [Contraseña] VARCHAR (100) NULL,
    [Id_Tipo]    INT           NULL,
    [Nombre]     VARCHAR (50)  NULL,
    [Apellido]   VARCHAR (50)  NULL,
    [Direccion]  VARCHAR (100) NULL,
    [Telefono]   VARCHAR (50)  NULL,
    [Estado]     BIT           NULL,
    [Puntos]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Id_Usuario] ASC),
    CONSTRAINT [FK_Usuario.Id_Tipo] FOREIGN KEY ([Id_Tipo]) REFERENCES [dbo].[Tipo_Usuario] ([Id_Tipo])
);

