IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Photos] (
    [id] int NOT NULL IDENTITY,
    [base64] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Cards] (
    [id] int NOT NULL IDENTITY,
    [id_photo] int NOT NULL,
    [name] nvarchar(max) NOT NULL,
    [status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cards] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Cards_Photos_id_photo] FOREIGN KEY ([id_photo]) REFERENCES [Photos] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cards_id_photo] ON [Cards] ([id_photo]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240417051225_Init', N'7.0.18');
GO

COMMIT;
GO

