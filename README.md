## Create database file for Apoteka project using the following script:

USE [master]
GO
/****** Object:  Database [Apoteka]    Script Date: 5.7.2018. 9:32:21 ******/
CREATE DATABASE [Apoteka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Apoteka', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Apoteka.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Apoteka_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Apoteka_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Apoteka] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Apoteka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Apoteka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Apoteka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Apoteka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Apoteka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Apoteka] SET ARITHABORT OFF 
GO
ALTER DATABASE [Apoteka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Apoteka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Apoteka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Apoteka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Apoteka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Apoteka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Apoteka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Apoteka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Apoteka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Apoteka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Apoteka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Apoteka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Apoteka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Apoteka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Apoteka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Apoteka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Apoteka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Apoteka] SET RECOVERY FULL 
GO
ALTER DATABASE [Apoteka] SET  MULTI_USER 
GO
ALTER DATABASE [Apoteka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Apoteka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Apoteka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Apoteka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Apoteka] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Apoteka', N'ON'
GO
ALTER DATABASE [Apoteka] SET QUERY_STORE = OFF
GO
USE [Apoteka]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Apoteka]
GO
/****** Object:  Table [dbo].[Klijent]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klijent](
	[klijentId] [int] NOT NULL,
	[ime] [varchar](50) NULL,
	[prezime] [varchar](50) NULL,
	[datumRodjenja] [date] NULL,
	[brojZdravstveneIskaznice] [int] NULL,
 CONSTRAINT [PK_Klijent] PRIMARY KEY CLUSTERED 
(
	[klijentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[korisnikId] [int] NOT NULL,
	[ime] [varchar](50) NULL,
	[prezime] [varchar](50) NULL,
	[datumRodjenja] [date] NULL,
	[radnoMjestoId] [int] NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[korisnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lijek]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lijek](
	[lijekId] [int] NOT NULL,
	[trgovackoIme] [varchar](100) NULL,
	[farmaceutskoIme] [varchar](100) NULL,
	[jacina] [varchar](50) NULL,
	[cijena] [float] NULL,
	[referencaUputa] [varchar](200) NULL,
	[kolicina] [int] NULL,
	[proizvodjacId] [int] NULL,
 CONSTRAINT [PK_Lijek] PRIMARY KEY CLUSTERED 
(
	[lijekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nabavljac]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nabavljac](
	[nabavljacId] [int] NOT NULL,
	[naziv] [varchar](50) NULL,
	[adresa] [varchar](200) NULL,
	[IBAN] [varchar](50) NULL,
 CONSTRAINT [PK_Nabavljac] PRIMARY KEY CLUSTERED 
(
	[nabavljacId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Narudzbenica]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzbenica](
	[narudzbenicaId] [int] NOT NULL,
	[datumIVrijemeIzdavanja] [datetime] NULL,
	[korisnikId] [int] NULL,
	[nabavljacId] [int] NULL,
	[adresaDostave] [varchar](200) NULL,
 CONSTRAINT [PK_Narudzbenica] PRIMARY KEY CLUSTERED 
(
	[narudzbenicaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NarudzbenicaLijek]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NarudzbenicaLijek](
	[narudzbenicaId] [int] NOT NULL,
	[lijekId] [int] NOT NULL,
	[kolicina] [nchar](10) NULL,
 CONSTRAINT [PK_NarudzbenicaLijek] PRIMARY KEY CLUSTERED 
(
	[narudzbenicaId] ASC,
	[lijekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvodjac]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvodjac](
	[proizvodjacId] [int] NOT NULL,
	[naziv] [varchar](100) NULL,
	[adresa] [varchar](100) NULL,
 CONSTRAINT [PK_Proizvodjac] PRIMARY KEY CLUSTERED 
(
	[proizvodjacId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[racunId] [int] NOT NULL,
	[datumIVrijemeIzdavanja] [datetime] NULL,
	[klijentId] [int] NULL,
	[korisnikId] [int] NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[racunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RacunLijek]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RacunLijek](
	[racunId] [int] NOT NULL,
	[lijekId] [int] NOT NULL,
	[kolicina] [int] NULL,
 CONSTRAINT [PK_RacunLijek] PRIMARY KEY CLUSTERED 
(
	[racunId] ASC,
	[lijekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RadnoMjesto]    Script Date: 5.7.2018. 9:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RadnoMjesto](
	[radnoMjestoId] [int] NOT NULL,
	[naziv] [varchar](50) NULL,
	[ovlastNarucivanja] [bit] NULL,
 CONSTRAINT [PK_RadnoMjesto] PRIMARY KEY CLUSTERED 
(
	[radnoMjestoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Korisnik]  WITH CHECK ADD  CONSTRAINT [FK_Korisnik_RadnoMjesto] FOREIGN KEY([radnoMjestoId])
REFERENCES [dbo].[RadnoMjesto] ([radnoMjestoId])
GO
ALTER TABLE [dbo].[Korisnik] CHECK CONSTRAINT [FK_Korisnik_RadnoMjesto]
GO
ALTER TABLE [dbo].[Lijek]  WITH CHECK ADD  CONSTRAINT [FK_Lijek_Proizvodjac] FOREIGN KEY([proizvodjacId])
REFERENCES [dbo].[Proizvodjac] ([proizvodjacId])
GO
ALTER TABLE [dbo].[Lijek] CHECK CONSTRAINT [FK_Lijek_Proizvodjac]
GO
ALTER TABLE [dbo].[Narudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_Narudzbenica_Korisnik] FOREIGN KEY([korisnikId])
REFERENCES [dbo].[Korisnik] ([korisnikId])
GO
ALTER TABLE [dbo].[Narudzbenica] CHECK CONSTRAINT [FK_Narudzbenica_Korisnik]
GO
ALTER TABLE [dbo].[Narudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_Narudzbenica_Nabavljac] FOREIGN KEY([nabavljacId])
REFERENCES [dbo].[Nabavljac] ([nabavljacId])
GO
ALTER TABLE [dbo].[Narudzbenica] CHECK CONSTRAINT [FK_Narudzbenica_Nabavljac]
GO
ALTER TABLE [dbo].[NarudzbenicaLijek]  WITH CHECK ADD  CONSTRAINT [FK_NarudzbenicaLijek_Lijek] FOREIGN KEY([lijekId])
REFERENCES [dbo].[Lijek] ([lijekId])
GO
ALTER TABLE [dbo].[NarudzbenicaLijek] CHECK CONSTRAINT [FK_NarudzbenicaLijek_Lijek]
GO
ALTER TABLE [dbo].[NarudzbenicaLijek]  WITH CHECK ADD  CONSTRAINT [FK_NarudzbenicaLijek_Narudzbenica] FOREIGN KEY([narudzbenicaId])
REFERENCES [dbo].[Narudzbenica] ([narudzbenicaId])
GO
ALTER TABLE [dbo].[NarudzbenicaLijek] CHECK CONSTRAINT [FK_NarudzbenicaLijek_Narudzbenica]
GO
ALTER TABLE [dbo].[Racun]  WITH CHECK ADD  CONSTRAINT [FK_Racun_Klijent] FOREIGN KEY([klijentId])
REFERENCES [dbo].[Klijent] ([klijentId])
GO
ALTER TABLE [dbo].[Racun] CHECK CONSTRAINT [FK_Racun_Klijent]
GO
ALTER TABLE [dbo].[Racun]  WITH CHECK ADD  CONSTRAINT [FK_Racun_Korisnik] FOREIGN KEY([korisnikId])
REFERENCES [dbo].[Korisnik] ([korisnikId])
GO
ALTER TABLE [dbo].[Racun] CHECK CONSTRAINT [FK_Racun_Korisnik]
GO
ALTER TABLE [dbo].[RacunLijek]  WITH CHECK ADD  CONSTRAINT [FK_RacunLijek_Lijek] FOREIGN KEY([lijekId])
REFERENCES [dbo].[Lijek] ([lijekId])
GO
ALTER TABLE [dbo].[RacunLijek] CHECK CONSTRAINT [FK_RacunLijek_Lijek]
GO
ALTER TABLE [dbo].[RacunLijek]  WITH CHECK ADD  CONSTRAINT [FK_RacunLijek_Racun] FOREIGN KEY([racunId])
REFERENCES [dbo].[Racun] ([racunId])
GO
ALTER TABLE [dbo].[RacunLijek] CHECK CONSTRAINT [FK_RacunLijek_Racun]
GO
USE [master]
GO
ALTER DATABASE [Apoteka] SET  READ_WRITE 
GO
