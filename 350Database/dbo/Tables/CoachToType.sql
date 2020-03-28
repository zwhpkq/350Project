CREATE TABLE CoachToType
(
	Id INT NOT NULL PRIMARY KEY,
	CoachId INT NOT NULL,
	TypeID INT NOT NULL,
	Foreign key (CoachId) References Coaches(Coach_ID),
	Foreign key (TypeID) References FitnessType(Id));
