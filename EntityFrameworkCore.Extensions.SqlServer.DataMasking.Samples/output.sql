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
CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Surname] nvarchar(max) NULL,
    [Surname2] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [DiscountCardNumber] int NOT NULL,
    [SampleProperty1] nvarchar(max) NULL,
    [SampleProperty2] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);

ALTER TABLE [Customers] ALTER COLUMN Surname ADD MASKED WITH (FUNCTION='default()');
ALTER TABLE [Customers] ALTER COLUMN Phone ADD MASKED WITH (FUNCTION='partial(2, "XX-XX", 1)');
ALTER TABLE [Customers] ALTER COLUMN DiscountCardNumber ADD MASKED WITH (FUNCTION='random(10, 100)');
CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [CustomerId] int NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
);

CREATE INDEX [IX_Order_CustomerId] ON [Order] ([CustomerId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250210132135_Initial', N'9.0.1');

COMMIT;
GO

