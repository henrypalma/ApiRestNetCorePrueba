USE [master]
GO
/****** Object:  Database [db_prueba_api]    Script Date: 23/08/2022 0:54:25 ******/
CREATE DATABASE [db_prueba_api]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_prueba_api', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.DESARROLLO\MSSQL\DATA\db_prueba_api.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_prueba_api_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.DESARROLLO\MSSQL\DATA\db_prueba_api_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_prueba_api] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_prueba_api].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_prueba_api] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_prueba_api] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_prueba_api] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_prueba_api] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_prueba_api] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_prueba_api] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_prueba_api] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_prueba_api] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_prueba_api] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_prueba_api] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_prueba_api] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_prueba_api] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_prueba_api] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_prueba_api] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_prueba_api] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_prueba_api] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_prueba_api] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_prueba_api] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_prueba_api] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_prueba_api] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_prueba_api] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_prueba_api] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_prueba_api] SET RECOVERY FULL 
GO
ALTER DATABASE [db_prueba_api] SET  MULTI_USER 
GO
ALTER DATABASE [db_prueba_api] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_prueba_api] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_prueba_api] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_prueba_api] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_prueba_api] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_prueba_api] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_prueba_api', N'ON'
GO
ALTER DATABASE [db_prueba_api] SET QUERY_STORE = OFF
GO
USE [db_prueba_api]
GO
/****** Object:  Table [dbo].[CuentasUsuario]    Script Date: 23/08/2022 0:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentasUsuario](
	[IdCuentaUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [varchar](20) NULL,
	[TipoCuenta] [varchar](20) NULL,
	[SaldoInicial] [money] NULL,
	[Estado] [bit] NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCuentaUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 23/08/2022 0:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[ValorMovimiento] [money] NULL,
	[TipoMovimiento] [varchar](20) NULL,
	[Estado] [bit] NULL,
	[SaldoDisponible] [money] NULL,
	[IdCuentaUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 23/08/2022 0:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrecioVenta] [float] NOT NULL,
	[PrecioCompra] [float] NOT NULL,
	[Stock] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 23/08/2022 0:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](200) NULL,
	[Direccion] [varchar](300) NULL,
	[Telefono] [varchar](20) NULL,
	[Clave] [varchar](200) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CuentasUsuario]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([IdCuentaUsuario])
REFERENCES [dbo].[CuentasUsuario] ([IdCuentaUsuario])
GO
USE [master]
GO
ALTER DATABASE [db_prueba_api] SET  READ_WRITE 
GO
