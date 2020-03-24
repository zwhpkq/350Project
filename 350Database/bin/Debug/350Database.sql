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
:setvar DefaultDataPath "C:\Users\danie\AppData\Local\Microsoft\VisualStudio\SSDT\350Project"
:setvar DefaultLogPath "C:\Users\danie\AppData\Local\Microsoft\VisualStudio\SSDT\350Project"

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
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
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
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


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
    [record_time]   DATETIME     NOT NULL,
    [Membership_ID] INT          NOT NULL,
    [height]        VARCHAR (15) NOT NULL,
    [weight]        VARCHAR (15) NOT NULL,
    [bmi]           FLOAT (53)   NOT NULL,
    [bmr]           FLOAT (53)   NOT NULL,
    [Fat_Percent]   VARCHAR (15) NOT NULL,
    [Fat_Mass]      VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([record_time] ASC, [Membership_ID] ASC)
);


GO
PRINT N'正在创建 [dbo].[Coaches]...';


GO
CREATE TABLE [dbo].[Coaches] (
    [Coach_ID]       INT          NOT NULL,
    [Coach_nick]     VARCHAR (20) NOT NULL,
    [Coach_Password] VARCHAR (20) NOT NULL,
    [First_Name]     VARCHAR (20) NOT NULL,
    [Last_Name]      VARCHAR (20) NOT NULL,
    [Hire_Start]     DATETIME     NOT NULL,
    [Hire_end]       DATETIME     NOT NULL,
    [Coach_Gender]   VARCHAR (10) NOT NULL,
    [Coach_Email]    VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Coach_ID] ASC),
    UNIQUE NONCLUSTERED ([Coach_Email] ASC)
);


GO
PRINT N'正在创建 [dbo].[Events]...';


GO
CREATE TABLE [dbo].[Events] (
    [Class_ID]    INT          NOT NULL,
    [Events_type] VARCHAR (20) NOT NULL,
    [Coach_ID]    INT          NOT NULL,
    [Class_Start] DATETIME     NOT NULL,
    [Class_End]   DATETIME     NOT NULL,
    [Class_Name]  VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Class_ID] ASC)
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
    [Member_Start]    DATETIME     NOT NULL,
    [Member_end]      DATETIME     NOT NULL,
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
PRINT N'正在创建 [dbo].[Attendance] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Attendance] WITH NOCHECK
    ADD FOREIGN KEY ([Membership_ID]) REFERENCES [dbo].[Members] ([Member_ID]);


GO
PRINT N'正在创建 [dbo].[Attendance] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Attendance] WITH NOCHECK
    ADD FOREIGN KEY ([Event_ID]) REFERENCES [dbo].[Events] ([Class_ID]);


GO
PRINT N'正在创建 [dbo].[Bodyinfo] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Bodyinfo] WITH NOCHECK
    ADD FOREIGN KEY ([Membership_ID]) REFERENCES [dbo].[Members] ([Member_ID]);


GO
PRINT N'正在创建 [dbo].[Events] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Events] WITH NOCHECK
    ADD FOREIGN KEY ([Coach_ID]) REFERENCES [dbo].[Coaches] ([Coach_ID]);


GO
PRINT N'正在创建 [dbo].[Members] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Members] WITH NOCHECK
    ADD CHECK (Member_Plan in (1,2,3,4));


GO
PRINT N'根据新创建的约束检查现有的数据';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Attendance'), OBJECT_ID(N'dbo.Bodyinfo'), OBJECT_ID(N'dbo.Events'), OBJECT_ID(N'dbo.Members'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'检查约束:' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'约束验证失败:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'验证约束时出错', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'更新完成。';


GO
