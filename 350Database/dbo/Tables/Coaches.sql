﻿CREATE TABLE Coaches 
(
	Coach_ID INT Identity(1,1),
	First_Name VARCHAR(20) NOT NULL,
	Last_Name VARCHAR(20) NOT NULL,
	Coach_Gender VARCHAR(10) NOT NULL,
	Coach_Email VARCHAR(30) NOT NULL Unique,
	PRIMARY KEY (Coach_ID));