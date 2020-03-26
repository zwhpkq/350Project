CREATE TABLE  Bodyinfo (
record_time DATETIME NOT NULL,
Membership_ID int NOT NULL,
height FLOAT NOT NULL,
weight FLOAT NOT NULL,
bmi FLOAT NOT NULL,
bmr FLOAT NOT NULL,
Fat_Percent FLOAT NOT NULL,
Fat_Mass FLOAT NOT NULL,
Primary key (record_time, Membership_ID),
Foreign key (Membership_ID) References Members(Member_ID));