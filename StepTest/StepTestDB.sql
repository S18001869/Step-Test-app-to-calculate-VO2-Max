-- Script Date: 30/12/2019 18:30  - ErikEJ.SqlCeScripting version 3.5.2.85
CREATE TABLE [User_Details] (
  [Id] INTEGER NOT NULL
, [Initials] TEXT NOT NULL
, [Age] INTEGER NOT NULL
, [Gender] TEXT NOT NULL
, [Step Height] INTEGER NOT NULL
, [MaxHR] INTEGER NOT NULL
, [80% MaxHR] NUMERIC NOT NULL
, [50% MaxHR] NUMERIC NOT NULL
, [TestDate] NUMERIC NOT NULL
, [Aerobic Capacity] INTEGER NOT NULL
, [Fitness Rating] TEXT NOT NULL
, CONSTRAINT [PK_User Details] PRIMARY KEY ([Id])
);
