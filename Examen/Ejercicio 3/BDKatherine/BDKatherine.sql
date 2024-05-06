USE [master]
GO
/****** Object:  Database [BDKatherine]    Script Date: 5/5/2024 22:06:50 ******/
CREATE DATABASE [BDKatherine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDKatherine', FILENAME = N'C:\SQLData\BDKatherine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDKatherine_log', FILENAME = N'C:\SQLData\BDKatherine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BDKatherine] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDKatherine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDKatherine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDKatherine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDKatherine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDKatherine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDKatherine] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDKatherine] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BDKatherine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDKatherine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDKatherine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDKatherine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDKatherine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDKatherine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDKatherine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDKatherine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDKatherine] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDKatherine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDKatherine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDKatherine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDKatherine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDKatherine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDKatherine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDKatherine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDKatherine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDKatherine] SET  MULTI_USER 
GO
ALTER DATABASE [BDKatherine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDKatherine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDKatherine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDKatherine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDKatherine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDKatherine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDKatherine] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDKatherine] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDKatherine]
GO
/****** Object:  Table [dbo].[cuenta]    Script Date: 5/5/2024 22:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta](
	[id] [int] NOT NULL,
	[persona_id] [int] NULL,
	[tipo_cuenta] [varchar](50) NULL,
	[saldo] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 5/5/2024 22:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[ci] [int] NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellidop] [varchar](100) NULL,
	[apellidom] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transaccion]    Script Date: 5/5/2024 22:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transaccion](
	[id] [int] NOT NULL,
	[cuenta_origen_id] [int] NULL,
	[cuenta_destino_id] [int] NULL,
	[monto] [float] NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1001, 32689, N'cuenta corriente', 500)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1002, 6864545, N'cuenta de ahorro', 2000)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1003, 548723, N'cuenta corriente', 300)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1004, 665421, N'cuenta de ahorro', 10000)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1005, 123789, N'cuenta de ahorro', 700)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1006, 999888, N'cuenta corriente', 1500)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1007, 555777, N'cuenta de ahorro', 4000)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1008, 987654, N'cuenta corriente', 200)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1009, 112233, N'cuenta de ahorro', 3000)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1010, 32689, N'cuenta corriente', 1000)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1011, 6864545, N'cuenta de ahorro', 6000)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1012, 547868, N'cuenta corriente', 200)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1013, 548723, N'cuenta de ahorro', 1500)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1014, 665421, N'cuenta corriente', 700)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1015, 123789, N'cuenta de ahorro', 2500)
INSERT [dbo].[cuenta] ([id], [persona_id], [tipo_cuenta], [saldo]) VALUES (1025, 547868, N'cuenta de ahorro', 5800)
GO
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (32689, N'Sandra', N'Mamani', N'Lima')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (112233, N'Sofía', N'Díaz', N'Jimenez')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (123789, N'Ana', N'Sánchez', N'Ruiz')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (547868, N'Lucas', N'Paredez', N'Salcedo')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (548723, N'María', N'Rodríguez', N'García')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (555777, N'Laura', N'Fernández', N'Pérez')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (665421, N'Juan', N'Martínez', N'López')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (987654, N'Diego', N'Gómez', N'Alvarez')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (999888, N'Pedro', N'Hernández', N'Díaz')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (2542752, N'María', N'López', N'Martínez')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (4277525, N'Juan', N'Pérez', N'García')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (6864545, N'Paola', N'Jimenez', N'Flores')
INSERT [dbo].[persona] ([ci], [nombre], [apellidop], [apellidom]) VALUES (8698235, N'Pedro', N'González', N'Sánchez')
GO
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (1, 1001, 1002, 100.5, CAST(N'2024-05-03' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (2, 1002, 1001, 75.25, CAST(N'2024-05-02' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (3, 1025, 1001, 50.75, CAST(N'2024-05-01' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (4, 1003, 1004, 150.2, CAST(N'2024-05-05' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (5, 1004, 1003, 300.75, CAST(N'2024-05-06' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (6, 1005, 1006, 200, CAST(N'2024-05-07' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (7, 1006, 1005, 50.5, CAST(N'2024-05-08' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (8, 1007, 1008, 1000, CAST(N'2024-05-09' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (9, 1008, 1009, 350.25, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (10, 1009, 1010, 180.3, CAST(N'2024-05-11' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (11, 1010, 1009, 50.75, CAST(N'2024-05-12' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (12, 1011, 1012, 300, CAST(N'2024-05-13' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (13, 1012, 1013, 75.5, CAST(N'2024-05-14' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (14, 1013, 1014, 150.25, CAST(N'2024-05-15' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (15, 1014, 1015, 200.75, CAST(N'2024-05-16' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (16, 1015, 1014, 100, CAST(N'2024-05-17' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (17, 1011, 1010, 50.5, CAST(N'2024-05-18' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (18, 1010, 1008, 75.75, CAST(N'2024-05-19' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (19, 1009, 1007, 150.25, CAST(N'2024-05-20' AS Date))
INSERT [dbo].[transaccion] ([id], [cuenta_origen_id], [cuenta_destino_id], [monto], [fecha]) VALUES (20, 1008, 1006, 200.5, CAST(N'2024-05-21' AS Date))
GO
ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD FOREIGN KEY([persona_id])
REFERENCES [dbo].[persona] ([ci])
GO
ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD FOREIGN KEY([cuenta_origen_id])
REFERENCES [dbo].[cuenta] ([id])
GO
ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD FOREIGN KEY([cuenta_destino_id])
REFERENCES [dbo].[cuenta] ([id])
GO
USE [master]
GO
ALTER DATABASE [BDKatherine] SET  READ_WRITE 
GO
