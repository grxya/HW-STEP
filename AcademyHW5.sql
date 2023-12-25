create database Academy;
use Academy;
go;

create table Curators(
Id int primary key identity(1, 1),
Name nvarchar(max) NOT NULL check(Name not like ''),
Surname nvarchar(max) NOT NULL check(Surname not like '')
);

create table Faculties(
Id int primary key identity(1, 1),
Financing money NOT NULL default 0 check(Financing>=0),
Name nvarchar(100) NOT NULL check(Name not like '') unique,
);

create table Departments(
Id int primary key identity(1, 1),
Financing money NOT NULL default 0 check(Financing>=0),
Name nvarchar(100) NOT NULL check(Name not like '') unique,
FacultyId int foreign key references Faculties
);

create table Groups(
Id int primary key identity(1, 1),
Name nvarchar(10) NOT NULL check(Name not like '') unique,
Year int NOT NULL check(Year>=1 and Year<=5),
DepartmentId int foreign key references Departments
);

create table GroupsCurator(
Id int primary key identity(1, 1),
CuratorId int foreign key references Curators,
GroupId int foreign key references Groups
);

create table Subjects(
Id int primary key identity(1, 1),
Name nvarchar(100) NOT NULL check(Name not like '') unique
);

create table Teachers(
Id int primary key identity(1, 1),
Name nvarchar(max) NOT NULL check(Name not like ''),
Surname nvarchar(max) NOT NULL check(Surname not like ''),
Salary money NOT NULL check(Salary>0)
);

create table Lectures(
Id int primary key identity(1, 1),
LectureRoom nvarchar(max) NOT NULL check(LectureRoom not like ''),
SubjectId int foreign key references Subjects,
TeacherId int foreign key references Teachers
);

create table GroupsLectures(
Id int primary key identity(1, 1),
LectureId int foreign key references Lectures,
GroupId int foreign key references Groups
);
go;

--
insert into Curators(Name, Surname) values(N'Felicity', N'Strange')
insert into Curators(Name, Surname) values(N'Helga', N'Goffe')

insert into Faculties(Financing, Name) values(50000, N'Computer Science')
insert into Faculties(Financing, Name) values(30000, N'Physics')

insert into Departments(Financing, Name, FacultyId) values(60000, N'Applied Mathematics', 1)
insert into Departments(Financing, Name, FacultyId) values(20000, N'Science', 2)

insert into Groups(Name, Year, DepartmentId) values(N'CS602', 3, 1)
insert into Groups(Name, Year, DepartmentId) values(N'P107', 5, 2)

insert into GroupsCurator(CuratorId, GroupId) values(1, 2)
insert into GroupsCurator(CuratorId, GroupId) values(2, 1)

insert into Subjects(Name) values(N'Database Theory')
insert into Subjects(Name) values(N'Electricity')

insert into Teachers(Name, Surname, Salary) values(N'Samantha', N'Adams', N'2000')
insert into Teachers(Name, Surname, Salary) values(N'Gus', N'MacGahy', N'2000')

insert into Lectures(LectureRoom, SubjectId, TeacherId) values(N'B103', 1, 1)
insert into Lectures(LectureRoom, SubjectId, TeacherId) values(N'B103', 2, 1)
insert into Lectures(LectureRoom, SubjectId, TeacherId) values(N'B103', 2, 2)

insert into GroupsLectures(LectureId, GroupId) values(1, 1)
insert into GroupsLectures(LectureId, GroupId) values(2, 2)
insert into GroupsLectures(LectureId, GroupId) values(3, 2)
go;
--

--1--
select *
from GroupsLectures
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId
inner join Groups on Groups.Id = GroupsLectures.GroupId;
go;
--или--
select Teachers.Name, Teachers.Surname, Subjects.Name, Groups.Name
from GroupsLectures
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Subjects on Subjects.Id = Lectures.SubjectId;
go;

--2--
select Faculties.Name
from Departments
inner join Faculties on Faculties.Id = Departments.FacultyId
where Departments.Financing > Faculties.Financing;
go;

--3--
select Curators.Surname, Groups.Name
from GroupsCurator
inner join Groups on Groups.Id = GroupsCurator.GroupId
inner join Curators on Curators.Id = GroupsCurator.CuratorId;
go;

--4--
select Teachers.Name, Teachers.Surname
from GroupsLectures
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId
inner join Groups on Groups.Id = GroupsLectures.GroupId
where Groups.Name = 'P107';
go;

--5--
select Teachers.Surname, Faculties.Name
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId;
go;

--6--
select Departments.Name, Groups.Name
from Groups
inner join Departments on Departments.Id = Groups.DepartmentId;
go;

--7--
select Subjects.Name
from Lectures
inner join Teachers on Teachers.Id = Lectures.TeacherId
inner join Subjects on Subjects.Id = Lectures.SubjectId
where Teachers.Name = 'Samantha' and Teachers.Surname = 'Adams';
go;

--8--
select Departments.Name
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Subjects on Subjects.Id = Lectures.SubjectId
where Subjects.Name = 'Database Theory';
go;

--9--
select Groups.Name
from Groups
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
where Faculties.Name = 'Computer Science';
go;

--10--
select Groups.Name, Faculties.Name
from Groups
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
where Groups.Year = 5;
go;

--11--
select Teachers.Name, Teachers.Surname, Subjects.Name, Groups.Name
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Subjects on Subjects.Id = Lectures.SubjectId
inner join Teachers on Teachers.Id = Lectures.TeacherId
where Lectures.LectureRoom = 'B103';
go;

