CREATE TABLE [dbo].[Quejas] (
    [Id_Quejas]   INT           NOT NULL,
    [Fecha]       DATE          NULL,
    [Id_Usuario]  INT           NULL,
    [Descripcion] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id_Quejas] ASC),
    CONSTRAINT [FK_Quejas.Id_Usuario] FOREIGN KEY ([Id_Usuario]) REFERENCES [dbo].[Usuario] ([Id_Usuario])
);

