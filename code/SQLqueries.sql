--admin
CREATE TABLE adminTable (
	adminID INT IDENTITY(100,1) PRIMARY KEY NOT NULL,
	fName VARCHAR(50),
	LName VARCHAR(50),
	adminEmail VARCHAR(50),
	adminPassword VARCHAR(50),
	adminDOB VARCHAR(50),
);
SELECT * from adminTable
--gymOwner 
CREATE TABLE gymOwnerTable (
	gymOwnerID INT IDENTITY(200,1) PRIMARY KEY NOT NULL,
	fName VARCHAR(50),
	LName VARCHAR(50),
	gymOwnerEmail VARCHAR(50),
	gymOwnerPassword VARCHAR(50),
	gymOwnerDOB VARCHAR (50),
);

SELECT * from gymOwnerTable

-- potential gymOwner to be approved by admin 
CREATE TABLE PotentialGymOwnerTable (
	PotentialGymOwnerID INT IDENTITY(200,2) PRIMARY KEY NOT NULL,
	fName VARCHAR(50),
	LName VARCHAR(50),
	PotentialGymOwnerEmail VARCHAR(50),
	PotentialGymOwnerPassword VARCHAR(50),
	PotentialGymOwnerDOB VARCHAR (50),

	PotentialGymName VARCHAR(50),
	PotentialGymLocation VARCHAR(50),
	PotentialGymOpeningTime VARCHAR(50),
	PotentialGymClosingTime VARCHAR(50),
	PotentialGymDesc VARCHAR(100),
);
SELECT * from PotentialGymOwnerTable
--gym
CREATE TABLE gymTable (
	gymID INT IDENTITY(300,1) PRIMARY KEY NOT NULL,
	gymOwnerID INT,
	gymName VARCHAR(50),
	gymLocation VARCHAR(50),
	gymOpeningTime VARCHAR(50),
	gymClosingTime VARCHAR(50),
	gymDesc VARCHAR(100),
	FOREIGN KEY (gymOwnerID) REFERENCES gymOwnerTable(gymOwnerID)
);
SELECT * from gymTable
--trainer
CREATE TABLE trainerTable (
	trainerID INT IDENTITY(500,1) PRIMARY KEY NOT NULL,
	fName VARCHAR(50),
	LName VARCHAR(50),
	trainerEmail VARCHAR(50),
	trainerPassword VARCHAR(50),
	trainerDOB VARCHAR(50),
	trainerRating decimal(10,2),
	trainerExp int ,
);

--trainer MxN gym
CREATE TABLE trainerGoesToGym (
	trainerID INT, 
	gymID INT, 
	PRIMARY KEY (trainerID, gymID),
	FOREIGN KEY (trainerID) REFERENCES trainerTable(trainerID),
	FOREIGN KEY (gymID) REFERENCES gymTable(gymID),
);

CREATE TABLE trainerQualification(
	trainerID INT, 
	qualiID INT IDENTITY(1,1), 
	PRIMARY KEY (trainerID, qualiID),
	FOREIGN KEY (trainerID) REFERENCES trainerTable(trainerID),
);


CREATE TABLE trainerSpecialty(
	trainerID INT, 
	specID INT IDENTITY(1,1), 
	PRIMARY KEY (trainerID, specID),
	FOREIGN KEY (trainerID) REFERENCES trainerTable(trainerID),
);


CREATE TABLE memberTable(
	memberID INT IDENTITY(600,1) PRIMARY KEY NOT NULL,
	fName VARCHAR(50),
	lName VARCHAR(50),
	memberEmail VARCHAR(50),
	memberPassword VARCHAR(50),
	memberShipType VARCHAR(50),
	startVARCHAR(50) VARCHAR(50),
	memberShipDuration VARCHAR(100), 
	customerSatisfaction INT, 
	gymID INT NOT NULL,
	FOREIGN KEY (gymID) REFERENCES gymTable(gymID)
);


CREATE TABLE trainingSess (
	trainingSesID INT IDENTITY(100,1) PRIMARY KEY,
	memberID INT, 
	trainerID INT, 
	TSVARCHAR(50) VARCHAR(100),
	TSDuration VARCHAR(50),
	TSTime VARCHAR(50),
	FOREIGN KEY (memberID) REFERENCES memberTable(memberID),
	FOREIGN KEY (trainerID) REFERENCES trainerTable(trainerID),
);

CREATE TABLE feedbackTable (
	fID INT IDENTITY(1,1) PRIMARY KEY,
	memberID INT,
	trainerID INT,
	review VARCHAR(100),
	rating int,
	FOREIGN KEY (memberID) REFERENCES memberTable(memberID),
	FOREIGN KEY (trainerID) REFERENCES trainerTable(trainerID),
);


CREATE TABLE mealXDPlan (
	mealID INT, 
	dietPlanID INT,
	PRIMARY KEY (mealID, dietPlanID),
	FOREIGN KEY (mealID) REFERENCES mealTable(mealID),
	FOREIGN KEY (dietPlanID) REFERENCES dietplanTABLE(dietPlanID),
);

CREATE TABLE PotentialTrainerTable (
	PotentialTrainerID INT IDENTITY(500,1) PRIMARY KEY NOT NULL,
	fName VARCHAR(50),
	LName VARCHAR(50),
	PotentialTrainerEmail VARCHAR(50),
	PotentialTrainerPassword VARCHAR(50),
	PotentialTrainerDOB VARCHAR(50),
	PotentialTrainerRating decimal(10,2),
	PotentialTrainerExp int ,
	PotentialTrainerGymName VARCHAR(100),
);




CREATE TABLE mealTable(
	mealID INT IDENTITY(800,1) PRIMARY KEY,
	Proteins numeric(10,2),
	Carbs numeric(10,2),
	Fats numeric(10,2),
	Fibers numeric(10,2),
	Cal numeric(10,2),
	dietPlanID int,
	FOREIGN KEY(dietPlanID) References dietplanTABLE(dietPlanID)
);


CREATE TABLE allergenTable(
	allergenID INT IDENTITY(1,1) PRIMARY KEY,
	allergenName VARCHAR(50),
	mealID INT,
	FOREIGN KEY(mealID) References mealTABLE(mealID)
);

CREATE TABLE WorkoutPlanTable(
	WorkoutPlanID INT IDENTITY(900,1) PRIMARY KEY,
	duration VARCHAR(50),
	purpose VARCHAR(50),
	explevel int,
	creatorID int,
);

CREATE TABLE workoutSchTable (
	workoutSchID INT IDENTITY(900,1) PRIMARY KEY, 
	workoutSchDay VARCHAR(50),
);


CREATE TABLE scheduleXplan (
	WorkoutPlanID INT, 
	workoutSchID INT, 
	PRIMARY KEY (WorkoutPlanID , workoutSchID),
	FOREIGN KEY (WorkoutPlanID) REFERENCES WorkoutPlanTable(WorkoutPlanID),
	FOREIGN KEY (workoutSchID) REFERENCES workoutSchTable(workoutSchID),
)
 
 CREATE TABLE dietplanTABLE(
	dietPlanID INT IDENTITY(700,1) PRIMARY KEY,
	totalProteins numeric(10,2),
	totalCarbs numeric(10,2),
	totalFats numeric(10,2),
	totalFibers numeric(10,2),
	totalCal numeric(10,2),
	creatorID int ,
	dietType VARCHAR(50),
	dietDesc VARCHAR(50),
	purpose VARCHAR(50)
);


CREATE TABLE exerciseTable (
	exeID INT IDENTITY(100,1) PRIMARY KEY, 
	workoutSchID INT, 
	exeName VARCHAR(50),
	exeDesc VARCHAR(50),
	exeDiff VARCHAR(50),
	exeSets INT,
	exeReps INT,
	exeRestInterval INT, --in secs
	FOREIGN KEY (workoutSchID) REFERENCES workoutSchTable(workoutSchID),
);



