USE [master]
GO

if exists (select * from sys.databases where name = N'TrackIt')
begin
		EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'TrackIt';
		ALTER DATABASE TrackIt SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE TrackIt;
end 

CREATE DATABASE TrackIt;
GO

USE TrackIt;
GO

CREATE TABLE Project (
	ProjectId CHAR(50) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	Summary VARCHAR(2000) NULL,
	DueDate DATE NOT NULL,
	IsActive BIT NOT NULL DEFAULT(1)
);

CREATE TABLE Worker (
	WorkerId INT PRIMARY KEY IDENTITY (1, 1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL
);

CREATE TABLE ProjectWorker (
	ProjectId CHAR(50) NOT NULL,
	WorkerId INT NOT NULL,
	CONSTRAINT pk_ProjectWorker PRIMARY KEY (ProjectId, WorkerId),
	CONSTRAINT fk_ProjectWorker_Project FOREIGN KEY (ProjectId)
		REFERENCES Project(ProjectId),
	CONSTRAINT fk_ProjectWorker_Worker FOREIGN KEY (WorkerId)
		REFERENCES Worker(WorkerId)
);

CREATE TABLE Task (
	TaskId INT PRIMARY KEY IDENTITY (1, 1),
	Title VARCHAR(100) NOT NULL,
	Details TEXT NULL,
	DueDate DATE NOT NULL,
	EstimatedHours DECIMAL(5,2) NULL,
	ProjectId CHAR(50) NOT NULL,
	WorkerId INT NOT NULL,
	CONSTRAINT fk_Task_ProjectWorker FOREIGN KEY (ProjectId, WorkerId)
		REFERENCES ProjectWorker(ProjectId, WorkerId)
);