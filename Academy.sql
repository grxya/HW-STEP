create database Academy;
go;

use Academy;

create table Groups(
	Id int primary key identity(1, 1),
	Name nvarchar(10) NOT NULL UNIQUE CHECK (LEN(Name)>0),
	Rating int NOT NULL CHECK (Rating>=0 AND Rating<=5),
	Year int NOT NULL CHECK (Year>=1 AND Year<=5)
);


create table Departments(
	Id int primary key identity(1, 1),
	Financing money NOT NULL DEFAULT 0 CHECK (Financing>=0),
	Name nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name)>0)
);

create table Faculties(
	Id int primary key identity(1, 1),
	Name nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name)>0)
);

create table Teachers(
	Id int primary key identity(1, 1),
	EmploymentDate date NOT NULL CHECK (EmploymentDate>='1990-01-01'),
	Name nvarchar(MAX) NOT NULL CHECK (LEN(Name)>0),
	Premium money NOT NULL DEFAULT 0 CHECK (Premium>=0),
	Salary money NOT NULL CHECK (Salary>0),
	Surname nvarchar(MAX) NOT NULL CHECK (LEN(Surname)>0)
);
go;

insert into Groups(Name, Rating, Year) values(N'602', 4, 3);
insert into Departments(Financing, Name) values(10000, N'Applied Mathematics')
insert into Faculties(Name) values(N'IT');
insert into Teachers(EmploymentDate, Name, Premium, Salary, Surname) values('1993-06-11', N'Irada', 200, 1500, N'Mammadova');
go;


select *
from Groups;

select *
from Departments;

select *
from Faculties;

select *
from Teachers;

