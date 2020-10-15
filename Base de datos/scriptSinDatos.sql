USE [master]
GO
/****** Object:  Database [Obligatorio1Db]    Script Date: 10/15/2020 3:03:25 PM ******/
CREATE DATABASE [Obligatorio1Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Obligatorio1Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Obligatorio1Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Obligatorio1Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Obligatorio1Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Obligatorio1Db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Obligatorio1Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Obligatorio1Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Obligatorio1Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Obligatorio1Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Obligatorio1Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Obligatorio1Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Obligatorio1Db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Obligatorio1Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Obligatorio1Db] SET  MULTI_USER 
GO
ALTER DATABASE [Obligatorio1Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Obligatorio1Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Obligatorio1Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Obligatorio1Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Obligatorio1Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Obligatorio1Db] SET QUERY_STORE = OFF
GO
USE [Obligatorio1Db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accommodations]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accommodations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Rating] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PricePerNight] [float] NOT NULL,
	[FullCapacity] [bit] NOT NULL,
	[TouristSpotId] [int] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accommodations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageWrappers]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageWrappers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[AccommodationId] [int] NULL,
 CONSTRAINT [PK_ImageWrappers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CheckIn] [datetime2](7) NOT NULL,
	[CheckOut] [datetime2](7) NOT NULL,
	[TotalGuests] [int] NOT NULL,
	[Babies] [int] NOT NULL,
	[Kids] [int] NOT NULL,
	[Adults] [int] NOT NULL,
	[GuestName] [nvarchar](max) NULL,
	[GuestLastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNumber] [int] NOT NULL,
	[Information] [nvarchar](max) NULL,
	[AccommodationForReservationId] [int] NULL,
	[ActualReservationStatus] [int] NOT NULL,
	[NewStatusDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristSpotCategories]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristSpotCategories](
	[CategoryId] [int] NOT NULL,
	[TouristSpotId] [int] NOT NULL,
 CONSTRAINT [PK_TouristSpotCategories] PRIMARY KEY CLUSTERED 
(
	[TouristSpotId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouristSpots]    Script Date: 10/15/2020 3:03:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouristSpots](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[RegionId] [int] NULL,
 CONSTRAINT [PK_TouristSpots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Accommodations_TouristSpotId]    Script Date: 10/15/2020 3:03:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accommodations_TouristSpotId] ON [dbo].[Accommodations]
(
	[TouristSpotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageWrappers_AccommodationId]    Script Date: 10/15/2020 3:03:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImageWrappers_AccommodationId] ON [dbo].[ImageWrappers]
(
	[AccommodationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_AccommodationForReservationId]    Script Date: 10/15/2020 3:03:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_AccommodationForReservationId] ON [dbo].[Reservations]
(
	[AccommodationForReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristSpotCategories_CategoryId]    Script Date: 10/15/2020 3:03:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_TouristSpotCategories_CategoryId] ON [dbo].[TouristSpotCategories]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TouristSpots_RegionId]    Script Date: 10/15/2020 3:03:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_TouristSpots_RegionId] ON [dbo].[TouristSpots]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservations] ADD  DEFAULT ((0)) FOR [ActualReservationStatus]
GO
ALTER TABLE [dbo].[Accommodations]  WITH CHECK ADD  CONSTRAINT [FK_Accommodations_TouristSpots_TouristSpotId] FOREIGN KEY([TouristSpotId])
REFERENCES [dbo].[TouristSpots] ([Id])
GO
ALTER TABLE [dbo].[Accommodations] CHECK CONSTRAINT [FK_Accommodations_TouristSpots_TouristSpotId]
GO
ALTER TABLE [dbo].[ImageWrappers]  WITH CHECK ADD  CONSTRAINT [FK_ImageWrappers_Accommodations_AccommodationId] FOREIGN KEY([AccommodationId])
REFERENCES [dbo].[Accommodations] ([Id])
GO
ALTER TABLE [dbo].[ImageWrappers] CHECK CONSTRAINT [FK_ImageWrappers_Accommodations_AccommodationId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Accommodations_AccommodationForReservationId] FOREIGN KEY([AccommodationForReservationId])
REFERENCES [dbo].[Accommodations] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Accommodations_AccommodationForReservationId]
GO
ALTER TABLE [dbo].[TouristSpotCategories]  WITH CHECK ADD  CONSTRAINT [FK_TouristSpotCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristSpotCategories] CHECK CONSTRAINT [FK_TouristSpotCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[TouristSpotCategories]  WITH CHECK ADD  CONSTRAINT [FK_TouristSpotCategories_TouristSpots_TouristSpotId] FOREIGN KEY([TouristSpotId])
REFERENCES [dbo].[TouristSpots] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TouristSpotCategories] CHECK CONSTRAINT [FK_TouristSpotCategories_TouristSpots_TouristSpotId]
GO
ALTER TABLE [dbo].[TouristSpots]  WITH CHECK ADD  CONSTRAINT [FK_TouristSpots_Regions_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([Id])
GO
ALTER TABLE [dbo].[TouristSpots] CHECK CONSTRAINT [FK_TouristSpots_Regions_RegionId]
GO
USE [master]
GO
ALTER DATABASE [Obligatorio1Db] SET  READ_WRITE 
GO
