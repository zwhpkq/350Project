﻿CREATE TABLE Coaches (Coach_ID INT NOT NULL,
Coach_nick VARCHAR(20) NOT NULL,
Coach_Password VARCHAR(20) NOT NULL, 
First_Name VARCHAR(20) NOT NULL,
Last_Name VARCHAR(20) NOT NULL,
Hire_Start TIMESTAMP NOT NULL,
Hire_end TIMESTAMP NOT NULL,
Coach_Gender VARCHAR(10) NOT NULL,
Coach_Email VARCHAR(30) NOT NULL Unique,
PRIMARY KEY (Coach_ID));