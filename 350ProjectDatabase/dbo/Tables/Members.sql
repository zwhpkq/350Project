CREATE TABLE Members (Member_ID INT NOT NULL, Member_nick VARCHAR(20) NOT NULL, Member_Password VARCHAR(20) NOT NULL, 
Real_Name VARCHAR(20) NOT NULL, Member_Plan INT NOT NULL, Member_Start TIMESTAMP NOT NULL,
Member_end TIMESTAMP NOT NULL, Member_Gender VARCHAR(10) NOT NULL, Member_Birthday TIMESTAMP NOT NULL, 
CHECK(Member_Plan in (1,2,3)),Member_Email VARCHAR(30) NOT NULL Unique,PRIMARY KEY (Member_ID));