﻿CREATE TABLE Events (Class_ID INT NOT NULL,
Events_type VARCHAR(20) NOT NULL, Coach_ID INT NOT NULL,
Class_Start DATETIME NOT NULL,
Class_End DATETIME NOT NULL,
Class_Name VARCHAR(20) NOT NULL,
PRIMARY KEY(Class_ID),
FOREIGN KEY (Coach_ID) REFERENCES Coaches(Coach_ID));