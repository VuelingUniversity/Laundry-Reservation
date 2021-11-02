CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NOT NULL, 
    [PhoneNumber] INT NOT NULL, 
    [Email] NCHAR(10) NOT NULL
)
DELETE  [dbo].[Table]

CREATE TABLE [dbo].[Machine]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Pin] INT NOT NULL, 
    [IsLocked] BIT NOT NULL, 
    [Enabled] BIT NOT NULL, 
    [Reservationid] INT NULL, 
    CONSTRAINT [FK_Machine_Reservationid] FOREIGN KEY ([Reservationid]) REFERENCES [Reservation]([Id]) 
)

INSERT INTO Reservation([Id],[Date],[PhoneNumber],[Email])
VALUES (1,02/11/2021,648619394,'alberto')
INSERT INTO [Machine]([Id],[Pin],[IsLocked],[Enabled],[Reservationid])
VALUES 
    (1,1234,0,1,null),
    (2,1234,0,1,null),
    (3,1234,0,1,null),
    (4,1234,0,1,null),
    (5,1234,0,1,null)