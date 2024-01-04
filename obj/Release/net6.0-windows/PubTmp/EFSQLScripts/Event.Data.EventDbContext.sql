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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230920112626_Group')
BEGIN
    CREATE TABLE [Groups] (
        [Id] int NOT NULL IDENTITY,
        [GroupTeamName] nvarchar(max) NOT NULL,
        [GroupName] nvarchar(max) NOT NULL,
        [GroupEmail] nvarchar(max) NOT NULL,
        [GroupPhone] nvarchar(max) NOT NULL,
        [GroupFieldStudy] nvarchar(max) NOT NULL,
        [GroupLastDegree] nvarchar(max) NOT NULL,
        [GroupCityOfStudy] nvarchar(max) NOT NULL,
        [GroupAdress] nvarchar(max) NOT NULL,
        [GroupGrowHistory] nvarchar(max) NULL,
        [GroupIdeaTitle] nvarchar(max) NOT NULL,
        [GroupRelatedTitle] nvarchar(max) NOT NULL,
        [GroupGeographicalArea] nvarchar(max) NOT NULL,
        [GroupDurationOfRun] nvarchar(max) NOT NULL,
        [GroupTargetSociety] nvarchar(max) NOT NULL,
        [GroupHaveConnectionToOther] nvarchar(max) NOT NULL,
        [GroupIntellectualProperty] nvarchar(max) NULL,
        [GroupInnovativenessOfTheIdea] nvarchar(max) NOT NULL,
        [GroupProjectProgress] nvarchar(max) NOT NULL,
        [GroupFinishedPrice] nvarchar(max) NOT NULL,
        [GroupCompetitorsInMarket] nvarchar(max) NOT NULL,
        [GroupChallengesAndRisks] nvarchar(max) NOT NULL,
        [GroupFile] nvarchar(max) NULL,
        CONSTRAINT [PK_Groups] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230920112626_Group')
BEGIN
    CREATE TABLE [GroupProjects] (
        [Id] int NOT NULL IDENTITY,
        [GroupPrTitle] nvarchar(max) NOT NULL,
        [GroupPrTime] nvarchar(max) NOT NULL,
        [GroupPrPrice] nvarchar(max) NOT NULL,
        [GroupPrJobLeader] nvarchar(max) NOT NULL,
        [GroupPrSeller] nvarchar(max) NOT NULL,
        [GroupPrStatus] nvarchar(max) NOT NULL,
        [GroupId] int NOT NULL,
        CONSTRAINT [PK_GroupProjects] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupProjects_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230920112626_Group')
BEGIN
    CREATE TABLE [GroupUsers] (
        [Id] int NOT NULL IDENTITY,
        [GroupUserName] nvarchar(max) NULL,
        [GroupUserDegree] nvarchar(max) NULL,
        [GroupUserCityOfStudy] nvarchar(max) NULL,
        [GroupUserJob] nvarchar(max) NULL,
        [GroupUserPhone] nvarchar(max) NULL,
        [GroupId] int NOT NULL,
        CONSTRAINT [PK_GroupUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupUsers_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Groups] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230920112626_Group')
BEGIN
    CREATE INDEX [IX_GroupProjects_GroupId] ON [GroupProjects] ([GroupId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230920112626_Group')
BEGIN
    CREATE INDEX [IX_GroupUsers_GroupId] ON [GroupUsers] ([GroupId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230920112626_Group')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230920112626_Group', N'6.0.21');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GroupProjects]') AND [c].[name] = N'GroupPrTitle');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [GroupProjects] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [GroupProjects] ALTER COLUMN [GroupPrTitle] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GroupProjects]') AND [c].[name] = N'GroupPrTime');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [GroupProjects] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [GroupProjects] ALTER COLUMN [GroupPrTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GroupProjects]') AND [c].[name] = N'GroupPrStatus');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [GroupProjects] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [GroupProjects] ALTER COLUMN [GroupPrStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GroupProjects]') AND [c].[name] = N'GroupPrSeller');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [GroupProjects] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [GroupProjects] ALTER COLUMN [GroupPrSeller] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GroupProjects]') AND [c].[name] = N'GroupPrPrice');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [GroupProjects] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [GroupProjects] ALTER COLUMN [GroupPrPrice] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GroupProjects]') AND [c].[name] = N'GroupPrJobLeader');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [GroupProjects] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [GroupProjects] ALTER COLUMN [GroupPrJobLeader] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230923024504_IdentityNew')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230923024504_IdentityNew', N'6.0.21');
END;
GO

COMMIT;
GO

