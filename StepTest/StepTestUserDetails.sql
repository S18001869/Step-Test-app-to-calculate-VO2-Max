-- Script Date: 30/12/2019 19:08  - ErikEJ.SqlCeScripting version 3.5.2.85
CREATE TABLE [User_Details] (
  [Id] INTEGER NOT NULL
, [Initials] TEXT NOT NULL
, [Age] INTEGER NOT NULL
, [Gender] TEXT NOT NULL
, [Step Height] INTEGER NOT NULL
, [MaxHR] INTEGER NOT NULL
, [80% Max HR] INTEGER NOT NULL
, [50% Max HR] INTEGER NOT NULL
, [TestDate] TEXT NOT NULL
, [Aerobic Capacity] INTEGER NOT NULL
, [Fitness Rating] TEXT NOT NULL
, CONSTRAINT [PK_User_Details] PRIMARY KEY ([Id])
);
