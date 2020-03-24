CREATE TABLE  Bodyinfo (
record_time DATETIME NOT NULL,
Membership_ID int NOT NULL,
height varchar(15) NOT NULL,
weight VARCHAR(15) NOT NULL,
bmi FLOAT NOT NULL,
bmr FLOAT NOT NULL,
Fat_Percent varchar(15) NOT NULL,
Fat_Mass varchar(15) NOT NULL,
Primary key (record_time, Membership_ID),
Foreign key (Membership_ID) References Members(Member_ID));