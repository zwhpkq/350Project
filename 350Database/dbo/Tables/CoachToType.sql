CREATE TABLE CoachToType
(
	Id INT Identity(1,1) PRIMARY KEY,
	CoachId INT NOT NULL,
	TypeID INT NOT NULL,
	Foreign key (CoachId) References Coaches(Coach_ID),
	Foreign key (TypeID) References FitnessType(Id));
