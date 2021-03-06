USE [master]
GO
/****** Object:  Database [MyDog]    Script Date: 2019-01-16 16:22:05 ******/
CREATE DATABASE [MyDog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyDog', FILENAME = N'C:\Users\Administrator\MyDog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyDog_log', FILENAME = N'C:\Users\Administrator\MyDog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MyDog] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyDog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyDog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyDog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyDog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyDog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyDog] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyDog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyDog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyDog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyDog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyDog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyDog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyDog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyDog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyDog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyDog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyDog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyDog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyDog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyDog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyDog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyDog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyDog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyDog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyDog] SET  MULTI_USER 
GO
ALTER DATABASE [MyDog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyDog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyDog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyDog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyDog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyDog] SET QUERY_STORE = OFF
GO
USE [MyDog]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MyDog]
GO
/****** Object:  Table [dbo].[Breed]    Script Date: 2019-01-16 16:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Breed](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Breed] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dog]    Script Date: 2019-01-16 16:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[BreedId] [int] NULL,
	[ExhibitorId] [int] NULL,
 CONSTRAINT [PK_Dog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exhibitor]    Script Date: 2019-01-16 16:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exhibitor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Mailadress] [nvarchar](50) NULL,
 CONSTRAINT [PK_Exhibitor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ring]    Script Date: 2019-01-16 16:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ring](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NULL,
 CONSTRAINT [PK_Ring] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RingBreed]    Script Date: 2019-01-16 16:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RingBreed](
	[BreedId] [int] NOT NULL,
	[RingId] [int] NOT NULL,
 CONSTRAINT [PK_RingBreed] PRIMARY KEY CLUSTERED 
(
	[BreedId] ASC,
	[RingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RingExhibitor]    Script Date: 2019-01-16 16:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RingExhibitor](
	[ExhibitorId] [int] NOT NULL,
	[RingId] [int] NOT NULL,
 CONSTRAINT [PK_RingExhibitor] PRIMARY KEY CLUSTERED 
(
	[ExhibitorId] ASC,
	[RingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Breed] ON 

INSERT [dbo].[Breed] ([Id], [Name]) VALUES (1, N'Pudel')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (2, N'Finsk lapphund')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (3, N'Leonberger')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (4, N'Golden retriever')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (5, N'Labrador')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (6, N'Schäfer')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (7, N'Mops')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (8, N'Fransk bulldog')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (9, N'Engelsk bulldog')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (10, N'Svensk lapphund')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (11, N'Irländsk setter')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (12, N'Boxer')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (13, N'Rottweiler')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (14, N'Shetland Sheepdog')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (15, N'Collie')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (16, N'Border collie')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (17, N'Australian shepherd')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (18, N'Jack Russel')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (19, N'Dvärgschnauzer')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (20, N'Schapendoes')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (21, N'Shitzu')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (22, N'Shiba')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (23, N'Samojed')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (24, N'Dalmatin')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (25, N'Chihuahua')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (26, N'Dvärgpinscher')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (27, N'Nova Scotia Duck Tolling Retriever')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (28, N'Engelsk bulldog')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (29, N'Weimaraner')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (30, N'Västgötaspets')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (31, N'Sharpei')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (32, N'Chow-chow')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (37, N'Tibetansk spaniel')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (38, N'Kinesisk nakenhund')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (1003, N'Beagle')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (1005, N'Cocker spaniel')
INSERT [dbo].[Breed] ([Id], [Name]) VALUES (2003, N'Papillon')
SET IDENTITY_INSERT [dbo].[Breed] OFF
SET IDENTITY_INSERT [dbo].[Dog] ON 

INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (3, N'Lumo', 20, 2)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (4, N'Freja', 1, 2)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1005, N'Sigge', 23, 3)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1006, N'Java', 18, 4)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1007, N'Javascript', 13, 4)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1008, N'Yoshi', 2, 1011)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1009, N'Erke', 2, 1011)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1010, N'Doris', 18, 1012)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1011, N'Gösta', 18, 1012)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1012, N'Pumba', 1003, 1013)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1013, N'Sture', 22, 1013)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1015, N'Duffy', 1005, 1015)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1016, N'Link', 3, 1016)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (1017, N'Ganondorf', 13, 1016)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (2008, N'Bruno', 2003, NULL)
INSERT [dbo].[Dog] ([Id], [Name], [BreedId], [ExhibitorId]) VALUES (2009, N'Mumin', 2003, 2011)
SET IDENTITY_INSERT [dbo].[Dog] OFF
SET IDENTITY_INSERT [dbo].[Exhibitor] ON 

INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (2, N'Eva', N'Larsson', N'0707456345', N'eva.larsson@telia.se')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (3, N'Gunnel', N'Johansson', N'0763433566', N'g_johansson@gmail.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (4, N'Bosse', N'Lindgren', N'0708654789', N'bosse.lindgren@outlook.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (1011, N'Rebecka', N'Carlsson', N'0768101024', N'rebecka.ls.carlsson@gmail.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (1012, N'Erika', N'Gleerup', N'0765345346', N'erika.gleerup@gmail.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (1013, N'Marie', N'Oskarsson', N'076534523', N'marie_o78@telia.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (1015, N'Tobias', N'Persson', N'0765345345', N'tobias.persson@gmail.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (1016, N'Olof', N'Wideström', N'0768123456', N'olof.w@gmail.com')
INSERT [dbo].[Exhibitor] ([Id], [FirstName], [LastName], [PhoneNumber], [Mailadress]) VALUES (2011, N'Alex', N'Sigvardsson', N'0788654456', N'alex.s@gmail.com')
SET IDENTITY_INSERT [dbo].[Exhibitor] OFF
SET IDENTITY_INSERT [dbo].[Ring] ON 

INSERT [dbo].[Ring] ([Id], [Number]) VALUES (1, 1)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (2, 2)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (3, 3)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (4, 4)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (5, 5)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (6, 6)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (7, 7)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (8, 8)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (9, 9)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (10, 10)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (11, 11)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (12, 12)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (13, 13)
INSERT [dbo].[Ring] ([Id], [Number]) VALUES (14, 14)
SET IDENTITY_INSERT [dbo].[Ring] OFF
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (1, 1)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (2, 2)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (3, 3)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (4, 4)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (5, 5)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (6, 6)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (7, 8)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (8, 9)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (9, 10)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (10, 11)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (11, 12)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (12, 13)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (14, 7)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (15, 7)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (16, 7)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (17, 7)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (18, 14)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (20, 12)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (21, 13)
INSERT [dbo].[RingBreed] ([BreedId], [RingId]) VALUES (22, 14)
INSERT [dbo].[RingExhibitor] ([ExhibitorId], [RingId]) VALUES (2, 3)
INSERT [dbo].[RingExhibitor] ([ExhibitorId], [RingId]) VALUES (3, 1)
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_Dog_Breed] FOREIGN KEY([BreedId])
REFERENCES [dbo].[Breed] ([Id])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_Dog_Breed]
GO
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_Dog_Exhibitor] FOREIGN KEY([ExhibitorId])
REFERENCES [dbo].[Exhibitor] ([Id])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_Dog_Exhibitor]
GO
ALTER TABLE [dbo].[RingBreed]  WITH CHECK ADD  CONSTRAINT [FK_RingBreed_Breed] FOREIGN KEY([BreedId])
REFERENCES [dbo].[Breed] ([Id])
GO
ALTER TABLE [dbo].[RingBreed] CHECK CONSTRAINT [FK_RingBreed_Breed]
GO
ALTER TABLE [dbo].[RingBreed]  WITH CHECK ADD  CONSTRAINT [FK_RingBreed_Ring] FOREIGN KEY([RingId])
REFERENCES [dbo].[Ring] ([Id])
GO
ALTER TABLE [dbo].[RingBreed] CHECK CONSTRAINT [FK_RingBreed_Ring]
GO
ALTER TABLE [dbo].[RingExhibitor]  WITH CHECK ADD  CONSTRAINT [FK_RingExhibitor_Exhibitor] FOREIGN KEY([ExhibitorId])
REFERENCES [dbo].[Exhibitor] ([Id])
GO
ALTER TABLE [dbo].[RingExhibitor] CHECK CONSTRAINT [FK_RingExhibitor_Exhibitor]
GO
ALTER TABLE [dbo].[RingExhibitor]  WITH CHECK ADD  CONSTRAINT [FK_RingExhibitor_Ring] FOREIGN KEY([RingId])
REFERENCES [dbo].[Ring] ([Id])
GO
ALTER TABLE [dbo].[RingExhibitor] CHECK CONSTRAINT [FK_RingExhibitor_Ring]
GO
USE [master]
GO
ALTER DATABASE [MyDog] SET  READ_WRITE 
GO
