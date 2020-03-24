CREATE TABLE Members 
(Member_ID INT Identity(1,1), 
Member_nick VARCHAR(20) NOT NULL,
Member_Password VARCHAR(20) NOT NULL,
First_Name VARCHAR(20) NOT NULL,
Last_Name VARCHAR(20) NOT NULL,
Member_Plan INT NOT NULL,
Member_End DATETIME NOT NULL,
Member_Gender VARCHAR(10) NOT NULL,
Member_Email VARCHAR(30) NOT NULL UNIQUE,
CHECK(Member_Plan in (1,2,3,4)),
PRIMARY KEY (Member_ID));