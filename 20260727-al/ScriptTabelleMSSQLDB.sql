/*
Script di distribuzione per DatabaseProjectEsercizioDb02

Questo codice è stato generato da uno strumento.
Le modifiche apportate a questo file possono causare un comportamento non corretto e andranno perse se
il codice viene rigenerato.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DatabaseProjectEsercizioDb02"
:setvar DefaultFilePrefix "DatabaseProjectEsercizioDb02"
:setvar DefaultDataPath "C:\Users\09ts-software\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\09ts-software\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Rilevare la modalità SQLCMD e disabilitare l'esecuzione dello script se la modalità SQLCMD non è supportata.
Per riabilitare lo script dopo aver abilitato la modalità SQLCMD, eseguire quanto segue:
IMPOSTARE NOEXEC SU OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Per la corretta esecuzione dello script è necessario abilitare la modalità SQLCMD.';
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
PRINT N'Creazione del database $(DatabaseName)...'
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
                RECOVERY FULL,
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
        PRINT N'Impossibile modificare le impostazioni di database. È necessario appartenere al ruolo SysAdmin per applicare queste impostazioni.';
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
        PRINT N'Impossibile modificare le impostazioni di database. È necessario appartenere al ruolo SysAdmin per applicare queste impostazioni.';
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
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, OPERATION_MODE = READ_WRITE, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creazione di Tabella [dbo].[Brands]...';


GO
CREATE TABLE [dbo].[Brands] (
    [BrandID]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandID] ASC),
    CONSTRAINT [UNI_BrandName] UNIQUE NONCLUSTERED ([BrandName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Categories]...';


GO
CREATE TABLE [dbo].[Categories] (
    [CategoryID]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [UNI_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Cities]...';


GO
CREATE TABLE [dbo].[Cities] (
    [CityID]     INT           IDENTITY (1, 1) NOT NULL,
    [ProvinceID] INT           NOT NULL,
    [CityName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityID] ASC),
    CONSTRAINT [UNI_CityName] UNIQUE NONCLUSTERED ([CityName] ASC, [ProvinceID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Customers]...';


GO
CREATE TABLE [dbo].[Customers] (
    [CustomerID]         NVARCHAR (50) NOT NULL,
    [CustomerFirstName]  NVARCHAR (50) NOT NULL,
    [CustomerLastName]   NVARCHAR (50) NOT NULL,
    [CustomerEmail]      NVARCHAR (50) NOT NULL,
    [CustomerCityID]     INT           NOT NULL,
    [CustomerSegmentID]  INT           NOT NULL,
    [CustomerSignupDate] DATE          NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[CustomerSegments]...';


GO
CREATE TABLE [dbo].[CustomerSegments] (
    [CustomerSegmentID]   INT           IDENTITY (1, 1) NOT NULL,
    [CustomerSegmentName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CustomerSegments] PRIMARY KEY CLUSTERED ([CustomerSegmentID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[OrderLines]...';


GO
CREATE TABLE [dbo].[OrderLines] (
    [OrderLineID]     NVARCHAR (50)   NOT NULL,
    [OrderID]         NVARCHAR (50)   NOT NULL,
    [ProductCode]     NVARCHAR (50)   NOT NULL,
    [UnitPriceEUR]    DECIMAL (10, 2) NOT NULL,
    [Quantity]        INT             NOT NULL,
    [DiscountPct]     DECIMAL (5, 2)  NOT NULL,
    [ShippingCostEUR] DECIMAL (10, 2) NOT NULL,
    [LineRevenueEUR]  DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED ([OrderLineID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Orders]...';


GO
CREATE TABLE [dbo].[Orders] (
    [OrderID]         NVARCHAR (50) NOT NULL,
    [OrderDate]       DATE          NOT NULL,
    [CustomerID]      NVARCHAR (50) NOT NULL,
    [SalesRepID]      NVARCHAR (50) NOT NULL,
    [SalesChannelID]  INT           NOT NULL,
    [WharehouseID]    NVARCHAR (50) NOT NULL,
    [PaymentMethodID] INT           NOT NULL,
    [OrderStatusID]   INT           NOT NULL,
    [DeliveryDate]    DATE          NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[OrderStatuses]...';


GO
CREATE TABLE [dbo].[OrderStatuses] (
    [OrderStatusID]   INT           IDENTITY (1, 1) NOT NULL,
    [OrderStatusName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED ([OrderStatusID] ASC),
    CONSTRAINT [UNI_OrderStatusName] UNIQUE NONCLUSTERED ([OrderStatusName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[PaymentMethods]...';


GO
CREATE TABLE [dbo].[PaymentMethods] (
    [PaymentMethodID]   INT           IDENTITY (1, 1) NOT NULL,
    [PaymentMethodName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([PaymentMethodID] ASC),
    CONSTRAINT [UNI_PaymentMethods] UNIQUE NONCLUSTERED ([PaymentMethodName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Products]...';


GO
CREATE TABLE [dbo].[Products] (
    [ProductCode] NVARCHAR (50)   NOT NULL,
    [ProductName] NVARCHAR (50)   NOT NULL,
    [CategoryID]  INT             NOT NULL,
    [BrandID]     INT             NOT NULL,
    [PriceEUR]    DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductCode] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Provinces]...';


GO
CREATE TABLE [dbo].[Provinces] (
    [ProvinceID]   INT           IDENTITY (1, 1) NOT NULL,
    [RegionID]     INT           NOT NULL,
    [ProvinceCode] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED ([ProvinceID] ASC),
    CONSTRAINT [UNI_ProvinceCode] UNIQUE NONCLUSTERED ([ProvinceCode] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[Regions]...';


GO
CREATE TABLE [dbo].[Regions] (
    [RegionID]   INT           IDENTITY (1, 1) NOT NULL,
    [RegionName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([RegionID] ASC),
    CONSTRAINT [UNI_RegionName] UNIQUE NONCLUSTERED ([RegionName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[SalesAreas]...';


GO
CREATE TABLE [dbo].[SalesAreas] (
    [SalesAreaID]   INT           IDENTITY (1, 1) NOT NULL,
    [SalesAreaName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesAreas] PRIMARY KEY CLUSTERED ([SalesAreaID] ASC),
    CONSTRAINT [UNI_SalesAreaName] UNIQUE NONCLUSTERED ([SalesAreaName] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[SalesChannels]...';


GO
CREATE TABLE [dbo].[SalesChannels] (
    [SalesChannelID]   INT           IDENTITY (1, 1) NOT NULL,
    [SalesChannelName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesChannels] PRIMARY KEY CLUSTERED ([SalesChannelID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[SalesReps]...';


GO
CREATE TABLE [dbo].[SalesReps] (
    [SalesRepID]        NVARCHAR (50) NOT NULL,
    [SalesRepFirstName] NVARCHAR (50) NOT NULL,
    [SalesRepLastName]  NVARCHAR (50) NOT NULL,
    [SalesRepEmail]     NVARCHAR (50) NOT NULL,
    [SalesAreaID]       INT           NOT NULL,
    CONSTRAINT [PK_SalesReps] PRIMARY KEY CLUSTERED ([SalesRepID] ASC)
);


GO
PRINT N'Creazione di Tabella [dbo].[StagingSales]...';


GO
CREATE TABLE [dbo].[StagingSales] (
    [OrderLineID]        NVARCHAR (50)   NOT NULL,
    [OrderID]            NVARCHAR (50)   NOT NULL,
    [OrderDate]          DATE            NOT NULL,
    [CustomerID]         NVARCHAR (50)   NOT NULL,
    [CustomerFirstName]  NVARCHAR (50)   NOT NULL,
    [CustomerLastName]   NVARCHAR (50)   NOT NULL,
    [CustomerEmail]      NVARCHAR (50)   NOT NULL,
    [CustomerPhone]      NVARCHAR (50)   NOT NULL,
    [CustomerCity]       NVARCHAR (50)   NOT NULL,
    [CustomerProvince]   NVARCHAR (50)   NOT NULL,
    [CustomerRegion]     NVARCHAR (50)   NOT NULL,
    [CustomerSegment]    NVARCHAR (50)   NOT NULL,
    [CustomerSignupDate] DATE            NOT NULL,
    [SalesRepID]         NVARCHAR (50)   NOT NULL,
    [SalesRepFirstName]  NVARCHAR (50)   NOT NULL,
    [SalesRepLastName]   NVARCHAR (50)   NOT NULL,
    [SalesRepEmail]      NVARCHAR (50)   NOT NULL,
    [SalesArea]          NVARCHAR (50)   NOT NULL,
    [ProductCode]        NVARCHAR (50)   NOT NULL,
    [ProductName]        NVARCHAR (50)   NOT NULL,
    [Category]           NVARCHAR (50)   NOT NULL,
    [Brand]              NVARCHAR (50)   NOT NULL,
    [UnitPriceEUR]       FLOAT (53)      NOT NULL,
    [Quantity]           INT             NOT NULL,
    [DiscountPct]        DECIMAL (5, 2)  NOT NULL,
    [WarehouseID]        NVARCHAR (50)   NOT NULL,
    [WarehouseName]      NVARCHAR (50)   NOT NULL,
    [WarehouseCity]      NVARCHAR (50)   NOT NULL,
    [WarehouseProvince]  NVARCHAR (50)   NOT NULL,
    [SalesChannel]       NVARCHAR (50)   NOT NULL,
    [PaymentMethod]      NVARCHAR (50)   NOT NULL,
    [OrderStatus]        NVARCHAR (50)   NOT NULL,
    [DeliveryDate]       DATE            NULL,
    [ShippingCostEUR]    DECIMAL (10, 2) NOT NULL,
    [LineRevenueEUR]     DECIMAL (10, 2) NOT NULL
);


GO
PRINT N'Creazione di Tabella [dbo].[Warehouses]...';


GO
CREATE TABLE [dbo].[Warehouses] (
    [WarehouseID]     NVARCHAR (50) NOT NULL,
    [WarehouseName]   NVARCHAR (50) NOT NULL,
    [WarehouseCityID] INT           NOT NULL,
    CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED ([WarehouseID] ASC)
);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Cities_Provinces]...';


GO
ALTER TABLE [dbo].[Cities]
    ADD CONSTRAINT [FK_Cities_Provinces] FOREIGN KEY ([ProvinceID]) REFERENCES [dbo].[Provinces] ([ProvinceID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Customers_CustomerSegments]...';


GO
ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [FK_Customers_CustomerSegments] FOREIGN KEY ([CustomerSegmentID]) REFERENCES [dbo].[CustomerSegments] ([CustomerSegmentID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Customers_Cities]...';


GO
ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [FK_Customers_Cities] FOREIGN KEY ([CustomerCityID]) REFERENCES [dbo].[Cities] ([CityID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_OrderLines_Products]...';


GO
ALTER TABLE [dbo].[OrderLines]
    ADD CONSTRAINT [FK_OrderLines_Products] FOREIGN KEY ([ProductCode]) REFERENCES [dbo].[Products] ([ProductCode]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_OrderLines_Orders]...';


GO
ALTER TABLE [dbo].[OrderLines]
    ADD CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_SalesReps]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_SalesReps] FOREIGN KEY ([SalesRepID]) REFERENCES [dbo].[SalesReps] ([SalesRepID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_PaymentMethods]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_PaymentMethods] FOREIGN KEY ([PaymentMethodID]) REFERENCES [dbo].[PaymentMethods] ([PaymentMethodID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_OrderStatuses]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_OrderStatuses] FOREIGN KEY ([OrderStatusID]) REFERENCES [dbo].[OrderStatuses] ([OrderStatusID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_SalesChannels]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_SalesChannels] FOREIGN KEY ([SalesChannelID]) REFERENCES [dbo].[SalesChannels] ([SalesChannelID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_Warehouses]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Warehouses] FOREIGN KEY ([WharehouseID]) REFERENCES [dbo].[Warehouses] ([WarehouseID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Orders_Customers]...';


GO
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Products_Brands]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brands] ([BrandID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Products_Categories]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Provinces_Regions]...';


GO
ALTER TABLE [dbo].[Provinces]
    ADD CONSTRAINT [FK_Provinces_Regions] FOREIGN KEY ([RegionID]) REFERENCES [dbo].[Regions] ([RegionID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_SalesReps_SalesAreas]...';


GO
ALTER TABLE [dbo].[SalesReps]
    ADD CONSTRAINT [FK_SalesReps_SalesAreas] FOREIGN KEY ([SalesAreaID]) REFERENCES [dbo].[SalesAreas] ([SalesAreaID]);


GO
PRINT N'Creazione di Chiave esterna [dbo].[FK_Warehouses_Cities]...';


GO
ALTER TABLE [dbo].[Warehouses]
    ADD CONSTRAINT [FK_Warehouses_Cities] FOREIGN KEY ([WarehouseCityID]) REFERENCES [dbo].[Cities] ([CityID]);


GO
PRINT N'Creazione di Vincolo CHECK [dbo].[CK_QuantityGreaterThanZero]...';


GO
ALTER TABLE [dbo].[OrderLines]
    ADD CONSTRAINT [CK_QuantityGreaterThanZero] CHECK ([Quantity]>(0));


GO
PRINT N'Creazione di Vista [dbo].[Vw_Customers_Info]...';


GO
CREATE VIEW [dbo].[Vw_Customers_Info]
AS
SELECT        dbo.Customers.CustomerID, dbo.Customers.CustomerFirstName, dbo.Customers.CustomerLastName, dbo.Customers.CustomerEmail, dbo.Customers.CustomerSignupDate, dbo.Cities.CityName, dbo.Provinces.ProvinceCode, 
                         dbo.CustomerSegments.CustomerSegmentName
FROM            dbo.Customers INNER JOIN
                         dbo.CustomerSegments ON dbo.Customers.CustomerSegmentID = dbo.CustomerSegments.CustomerSegmentID INNER JOIN
                         dbo.Cities ON dbo.Customers.CustomerCityID = dbo.Cities.CityID INNER JOIN
                         dbo.Provinces ON dbo.Cities.ProvinceID = dbo.Provinces.ProvinceID INNER JOIN
                         dbo.Regions ON dbo.Provinces.RegionID = dbo.Regions.RegionID
GO
PRINT N'Creazione di Proprietà estesa [dbo].[Vw_Customers_Info].[MS_DiagramPane2]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vw_Customers_Info';


GO
PRINT N'Creazione di Proprietà estesa [dbo].[Vw_Customers_Info].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Customers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CustomerSegments"
            Begin Extent = 
               Top = 6
               Left = 278
               Bottom = 102
               Right = 498
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Cities"
            Begin Extent = 
               Top = 6
               Left = 536
               Bottom = 119
               Right = 727
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Provinces"
            Begin Extent = 
               Top = 6
               Left = 765
               Bottom = 119
               Right = 956
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Regions"
            Begin Extent = 
               Top = 102
               Left = 278
               Bottom = 198
               Right = 469
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vw_Customers_Info';


GO
PRINT N'Creazione di Proprietà estesa [dbo].[Vw_Customers_Info].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Vw_Customers_Info';


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
PRINT N'Aggiornamento completato.';


GO
