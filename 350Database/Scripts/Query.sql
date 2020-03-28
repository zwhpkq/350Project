Insert INTO Plans Values (1, 1,0,0,100);
GO

Insert INTO Plans Values (2, 0,6,0,60);
GO

Insert INTO Plans Values (3, 0,3,0,35);
GO

Insert INTO Plans Values (4, 0,1,0,15);
GO

Insert INTO Plans Values (5, 0,0,7,5);
GO

Insert INTO Plans Values (6, 0,0,7,0);
GO


Insert INTO FitnessType(Id,Descript) Values ( 1,'BodyPump');
GO


Insert INTO FitnessType(Id,Descript) Values ( 2,'BodyJam');
GO


Insert INTO FitnessType(Id,Descript) Values ( 3,'BodyCombat');
GO


Insert INTO FitnessType(Id,Descript) Values ( 4,'HIIT');
GO


Insert INTO FitnessType(Id,Descript) Values ( 5,'BattleRope');
GO

Insert INTO FitnessType(Id,Descript) Values ( 6,'BikeRiding');
GO

Insert INTO FitnessType(Id,Descript) Values (7,'TRX');
GO

Insert INTO FitnessType(Id,Descript) Values (8,'Crossfit');
GO

Insert INTO FitnessType(Id,Descript) Values (9,'Yoga');
GO


Insert INTO Coaches(Coach_ID,First_Name,Last_Name,Coach_Gender,Coach_Email) Values (1,'Peter','Zhang','Male','wez955@mail.usask.ca');
GO

Insert INTO Coaches(Coach_ID,First_Name,Last_Name,Coach_Gender,Coach_Email) Values (2,'Leo','Wang','Male','yaw677@mail.usask.ca');
GO

Insert INTO Coaches(Coach_ID,First_Name,Last_Name,Coach_Gender,Coach_Email) Values (3,'Daniel','Li','Male','nil920@mail.usask.ca');
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (1,1, 1);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (2,1, 3);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (3,1, 5);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (4,2, 2);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (5,2, 4);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (6,2, 6);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (7,3, 7);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (8,3, 8);
GO

Insert INTO CoachToType(Id, CoachId,TypeID) Values (9,3, 9);
GO

Insert into Events values (1,1,1,'2020/4/1 10:00:00','2020/4/1 12:00:00', 'Event1');
GO

Insert into Events values (2,2,2,'2020/4/12 12:00:00','2020/4/12 14:00:00', 'Event2');
GO

Insert into Events values (3,7,3,'2020/4/15 12:00:00','2020/4/15 14:00:00', 'Event3');
GO


Insert into Events values (4,4,2,'2020/4/22 14:00:00','2020/4/15 16:00:00', 'Event4');
GO