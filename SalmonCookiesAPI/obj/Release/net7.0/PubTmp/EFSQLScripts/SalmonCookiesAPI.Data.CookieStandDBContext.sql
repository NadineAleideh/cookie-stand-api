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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231004095530_one')
BEGIN
    CREATE TABLE [CookieStands] (
        [Id] int NOT NULL IDENTITY,
        [Location] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [MinimumCustomersPerHour] int NOT NULL,
        [MaximumCustomersPerHour] int NOT NULL,
        [AverageCookiesPerSale] float NOT NULL,
        [Owner] nvarchar(max) NULL,
        CONSTRAINT [PK_CookieStands] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231004095530_one')
BEGIN
    CREATE TABLE [hourlySale] (
        [Id] int NOT NULL IDENTITY,
        [StandCookieId] int NOT NULL,
        [salesvalue] int NOT NULL,
        [cookieStandId] int NOT NULL,
        CONSTRAINT [PK_hourlySale] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_hourlySale_CookieStands_cookieStandId] FOREIGN KEY ([cookieStandId]) REFERENCES [CookieStands] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231004095530_one')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AverageCookiesPerSale', N'Description', N'Location', N'MaximumCustomersPerHour', N'MinimumCustomersPerHour', N'Owner') AND [object_id] = OBJECT_ID(N'[CookieStands]'))
        SET IDENTITY_INSERT [CookieStands] ON;
    EXEC(N'INSERT INTO [CookieStands] ([Id], [AverageCookiesPerSale], [Description], [Location], [MaximumCustomersPerHour], [MinimumCustomersPerHour], [Owner])
    VALUES (1, 2.5E0, N''description1'', N''Amman'', 7, 3, N''Person1''),
    (2, 2.5E0, N''description2'', N''Irbid'', 7, 3, N''Person2'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AverageCookiesPerSale', N'Description', N'Location', N'MaximumCustomersPerHour', N'MinimumCustomersPerHour', N'Owner') AND [object_id] = OBJECT_ID(N'[CookieStands]'))
        SET IDENTITY_INSERT [CookieStands] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231004095530_one')
BEGIN
    CREATE INDEX [IX_hourlySale_cookieStandId] ON [hourlySale] ([cookieStandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231004095530_one')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231004095530_one', N'7.0.11');
END;
GO

COMMIT;
GO

