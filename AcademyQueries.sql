create database Academy;
go;

use Academy;

create table Groups(
	Id int primary key identity(1, 1),
	Name nvarchar(10) NOT NULL UNIQUE CHECK (LEN(Name)>0),
	Rating int NOT NULL CHECK (Rating BETWEEN 0 AND 5),
	Year int NOT NULL CHECK (Year BETWEEN 1 AND 5)
);

create table Departments(
	Id int primary key identity(1, 1),
	Financing money NOT NULL DEFAULT 0 CHECK (Financing>=0),
	Name nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name)>0)
);

create table Faculties(
	Id int primary key identity(1, 1),
    Dean nvarchar(MAX) NOT NULL CHECK (LEN(Dean)>0),
	Name nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name)>0)
);

create table Teachers(
	Id int primary key identity(1, 1),
	EmploymentDate date NOT NULL CHECK (EmploymentDate>='1990-01-01'),
    IsAssistant bit NOT NULL DEFAULT 0,
    IsProfessor bit NOT NULL DEFAULT 0,
	Name nvarchar(MAX) NOT NULL CHECK (LEN(Name)>0),
    Position nvarchar(MAX) NOT NULL CHECK (LEN(Position)>0),
	Premium money NOT NULL DEFAULT 0 CHECK (Premium>=0),
	Salary money NOT NULL CHECK (Salary>0),
	Surname nvarchar(MAX) NOT NULL CHECK (LEN(Surname)>0)
);
go;

--1--
select Name, Financing, Id
from Departments
go;

--2--
select Name as GroupName, Rating as  GroupRating
from Groups;
go;

--3--
select Surname, (Salary/Premium) as SalaryToPremium, (Salary/(Salary+Premium)) as SalaryToIncome
from Teachers;
go;

--4--
select concat('The dean of faculty ', name, ' is ', Dean, '.') as FacultyInfo
from Faculties;
go;

--5--
select Surname
from Teachers
where IsProfessor = 1 and Salary>1050;
go;

--6--
select Name
from Departments
where Financing<11000 or Financing>25000;
go;

--7--
select Name
from Faculties
where not Name = 'Computer Science'
go;

--8--
select Surname, Position
from Teachers
where IsProfessor = 0;
go;

--9--
select Surname, Position, Salary, Premium
from Teachers
where IsAssistant = 1 and Premium between 160 and 550;
go;

--10--
select Surname, Salary
from Teachers
where IsAssistant = 1;
go;

--11--
select Surname, Position
from Teachers
where EmploymentDate < '2000-01-01';
go;

--12--
select Name as 'Name of Department'
from Departments
where Name < 'Software Development'
go;

--13--
select Surname
from Teachers
where IsAssistant = 1 and (Salary+Premium)<=1200;
go;

--14--
select Name
from Groups
where Year=5 and Rating between 2 and 4;
go;

--15--
select Surname
from Teachers
where IsAssistant = 1 and (Salary<550 or Premium<200);
go;