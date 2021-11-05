CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NAME VARCHAR(30) NOT NULL,
);

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id) CHECK(PlanetId > 0)
);

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY(0,1),
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate Date NOT NULL
);


CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY(0,1),
	Name VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
);

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY(0,1),
	JourneyStart Datetime2 NOT NULL,
	JourneyEnd Datetime2 NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id) CHECK(DestinationSpaceportId >= 0),
	SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id) CHECK (SpaceshipId >= 0)
);

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY(0,1),
	CardNumber VARCHAR(10) UNIQUE NOT NULL CHECK(LEN(CardNumber) = 10),
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
);
