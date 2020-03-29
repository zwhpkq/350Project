/*
350Database 的部署脚本

此代码由工具生成。
如果重新生成此代码，则对此文件的更改可能导致
不正确的行为并将丢失。
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "350Database"
:setvar DefaultFilePrefix "350Database"
:setvar DefaultDataPath "C:\Users\confu\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\confu\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
请检测 SQLCMD 模式，如果不支持 SQLCMD 模式，请禁用脚本执行。
要在启用 SQLCMD 模式后重新启用脚本，请执行:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'要成功执行此脚本，必须启用 SQLCMD 模式。';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'正在创建 $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'无法修改数据库设置。您必须是 SysAdmin 才能应用这些设置。';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'无法修改数据库设置。您必须是 SysAdmin 才能应用这些设置。';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'正在创建 [dbo].[Attendance]...';


GO
CREATE TABLE [dbo].[Attendance] (
    [Id]            INT NOT NULL,
    [Membership_ID] INT NOT NULL,
    [Event_ID]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Bodyinfo]...';


GO
CREATE TABLE [dbo].[Bodyinfo] (
    [record_time]   DATETIME   NOT NULL,
    [Membership_ID] INT        NOT NULL,
    [height]        FLOAT (53) NOT NULL,
    [weight]        FLOAT (53) NOT NULL,
    [bmi]           FLOAT (53) NOT NULL,
    [bmr]           FLOAT (53) NOT NULL,
    [Fat_Percent]   FLOAT (53) NOT NULL,
    [Fat_Mass]      FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([record_time] ASC, [Membership_ID] ASC)
);


GO
PRINT N'正在创建 [dbo].[Coaches]...';


GO
CREATE TABLE [dbo].[Coaches] (
    [Coach_ID]     INT          IDENTITY (1, 1) NOT NULL,
    [First_Name]   VARCHAR (20) NOT NULL,
    [Last_Name]    VARCHAR (20) NOT NULL,
    [Coach_Gender] VARCHAR (10) NOT NULL,
    [Coach_Email]  VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Coach_ID] ASC),
    UNIQUE NONCLUSTERED ([Coach_Email] ASC)
);


GO
PRINT N'正在创建 [dbo].[CoachToType]...';


GO
CREATE TABLE [dbo].[CoachToType] (
    [Id]      INT NOT NULL,
    [CoachId] INT NOT NULL,
    [TypeID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Events]...';


GO
CREATE TABLE [dbo].[Events] (
    [Class_ID]    INT          NOT NULL,
    [Events_type] INT          NOT NULL,
    [Coach_ID]    INT          NOT NULL,
    [Class_Start] DATETIME     NOT NULL,
    [Class_End]   DATETIME     NOT NULL,
    [Class_Name]  VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Class_ID] ASC)
);


GO
PRINT N'正在创建 [dbo].[FitnessType]...';


GO
CREATE TABLE [dbo].[FitnessType] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Descript] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Gallery]...';


GO
CREATE TABLE [dbo].[Gallery] (
    [ImageId]   INT           NOT NULL,
    [Title]     VARCHAR (20)  NOT NULL,
    [ImagePath] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ImageId] ASC)
);


GO
PRINT N'正在创建 [dbo].[Members]...';


GO
CREATE TABLE [dbo].[Members] (
    [Member_ID]       INT          NOT NULL,
    [Member_nick]     VARCHAR (20) NOT NULL,
    [Member_Password] VARCHAR (20) NOT NULL,
    [First_Name]      VARCHAR (20) NOT NULL,
    [Last_Name]       VARCHAR (20) NOT NULL,
    [Member_Plan]     INT          NOT NULL,
    [Member_End]      DATETIME     NOT NULL,
    [Member_Gender]   VARCHAR (10) NOT NULL,
    [Member_Email]    VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Member_ID] ASC),
    UNIQUE NONCLUSTERED ([Member_Email] ASC)
);


GO
PRINT N'正在创建 [dbo].[Plans]...';


GO
CREATE TABLE [dbo].[Plans] (
    [Plan_Id]    INT        NOT NULL,
    [plan_Year]  INT        NOT NULL,
    [plan_Month] INT        NOT NULL,
    [plan_Day]   INT        NOT NULL,
    [Price]      FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Plan_Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Rating]...';


GO
CREATE TABLE [dbo].[Rating] (
    [Rate_Id]         INT           NOT NULL,
    [Mark]            INT           NOT NULL,
    [Review]          VARCHAR (MAX) NULL,
    [Member_Id]       INT           NOT NULL,
    [Member_Username] VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Rate_Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Attendance] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Attendance]
    ADD FOREIGN KEY ([Membership_ID]) REFERENCES [dbo].[Members] ([Member_ID]);


GO
PRINT N'正在创建 [dbo].[Attendance] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Attendance]
    ADD FOREIGN KEY ([Event_ID]) REFERENCES [dbo].[Events] ([Class_ID]);


GO
PRINT N'正在创建 [dbo].[Bodyinfo] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Bodyinfo]
    ADD FOREIGN KEY ([Membership_ID]) REFERENCES [dbo].[Members] ([Member_ID]);


GO
PRINT N'正在创建 [dbo].[CoachToType] 上未命名的约束...';


GO
ALTER TABLE [dbo].[CoachToType]
    ADD FOREIGN KEY ([CoachId]) REFERENCES [dbo].[Coaches] ([Coach_ID]);


GO
PRINT N'正在创建 [dbo].[CoachToType] 上未命名的约束...';


GO
ALTER TABLE [dbo].[CoachToType]
    ADD FOREIGN KEY ([TypeID]) REFERENCES [dbo].[FitnessType] ([Id]);


GO
PRINT N'正在创建 [dbo].[Events] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Events]
    ADD FOREIGN KEY ([Coach_ID]) REFERENCES [dbo].[Coaches] ([Coach_ID]);


GO
PRINT N'正在创建 [dbo].[Events] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Events]
    ADD FOREIGN KEY ([Events_type]) REFERENCES [dbo].[FitnessType] ([Id]);


GO
PRINT N'正在创建 [dbo].[Members] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Members]
    ADD CHECK (Member_Plan in (1,2,3,4));


GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'更新完成。';


GO
