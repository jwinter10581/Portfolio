CREATE DATABASE MovieCatalogue;
GO

USE MovieCatalogue;
GO

CREATE TABLE Genre (
	GenreID int identity(1,1) primary key,
	GenreName nvarchar(30) not null
)

CREATE TABLE Rating (
	RatingID int identity(1,1) primary key,
	RatingName varchar(5) not null
)

CREATE TABLE Director (
	DirectorID int identity(1,1) primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	BirthDate date null
)

CREATE TABLE Actor (
	ActorID int identity(1,1) primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	BirthDate date null
)

CREATE TABLE Movie (
	MovieID int identity(1,1) primary key,
	GenreID int foreign key references Genre(GenreID) not null,
	DirectorID int foreign key references Director(DirectorID) null,
	RatingID int foreign key references Rating(RatingID) null,
	Title nvarchar(128) not null,
	ReleaseDate date null
)

CREATE TABLE CastMember (
	CastMemberID int identity(1,1) primary key,
	ActorID int foreign key references Actor(ActorID) not null,
	MovieID int foreign key references Movie(MovieID) not null,
	[Role] nvarchar(50) not null,
)

