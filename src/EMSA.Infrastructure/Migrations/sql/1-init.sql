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

IF SCHEMA_ID(N'product') IS NULL EXEC(N'CREATE SCHEMA [product];');
GO

CREATE TABLE [product].[Product] (
    [Id] bigint NOT NULL IDENTITY,
    [ProductName] nvarchar(250) NOT NULL,
    [WholeSalePrice] decimal(18,2) NOT NULL,
    [SalePrice] decimal(18,2) NOT NULL,
    [ImportPrice] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Product_ProductName] ON [product].[Product] ([ProductName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230814080510_Init', N'6.0.20');
GO

COMMIT;
GO

