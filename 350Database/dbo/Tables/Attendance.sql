CREATE TABLE Attendance
(
        Id INT NOT NULL PRIMARY KEY,
	Membership_ID INT NOT NULL,
	Event_ID INT NOT NULL,
	Foreign key (Membership_ID) References Members(Member_ID),
	Foreign key (Event_ID) References Events(Class_ID));