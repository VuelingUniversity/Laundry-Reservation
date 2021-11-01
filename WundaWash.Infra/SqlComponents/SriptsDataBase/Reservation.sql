USE [WundaWash]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 30/10/2021 11:17:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id_reservation] [int] IDENTITY(1,1) NOT NULL,
	[Id_patron] [int] NOT NULL,
	[Id_machine] [int] NOT NULL,
	[Pin] [int] NOT NULL,
	[DateReservation] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (1, 7, 13, 1882, CAST(N'2021-12-15T13:54:09.720' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (2, 5, 21, 3476, CAST(N'2021-12-25T17:45:11.750' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (3, 2, 18, 2569, CAST(N'2021-11-06T11:35:09.510' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (4, 3, 8, 2318, CAST(N'2021-12-03T13:59:55.840' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (5, 10, 24, 1813, CAST(N'2021-12-10T06:52:13.660' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (6, 4, 11, 4694, CAST(N'2021-12-18T19:56:42.420' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (7, 6, 9, 4482, CAST(N'2021-11-20T02:27:12.760' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (8, 9, 25, 2587, CAST(N'2021-12-24T21:56:39.580' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (9, 8, 1, 3882, CAST(N'2021-12-21T15:40:31.310' AS DateTime))
INSERT [dbo].[Reservation] ([Id_reservation], [Id_patron], [Id_machine], [Pin], [DateReservation]) VALUES (10, 1, 15, 3329, CAST(N'2021-12-28T01:22:40.160' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reservation] OFF
