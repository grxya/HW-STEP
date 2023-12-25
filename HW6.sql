create database Academy;
use Academy;
go;

create table Faculties(
Id int primary key identity(1,1),
Name nvarchar(100) NOT NULL unique check (len(Name) > 0),
);

create table Departments(
Id int primary key identity(1,1),
Financing money NOT NULL default 0 check(Financing>=0),
Name nvarchar(100) NOT NULL unique check (len(Name) > 0),
FacultyId int foreign key references Faculties
);

create table Groups(
Id int primary key identity(1,1),
Name nvarchar(10) NOT NULL unique check (len(Name) > 0),
Year int NOT NULL check(Year>=1 and Year<=5),
DepartmentId int foreign key references Departments
);

create table Students(
Id int primary key identity(1,1),
Name nvarchar(max) NOT NULL check (len(Name) > 0),
Surname nvarchar(max) NOT NULL check (len(Surname) > 0),
Age int NOT NULL check(Age>14)
);

create table GroupData(
Id int primary key identity(1,1),
GroupId int foreign key references Groups,
StudentId int foreign key references Students
);

create table Subjects(
Id int primary key identity(1,1),
Name nvarchar(100) NOT NULL unique check (len(Name) > 0)
);

create table Teachers(
Id int primary key identity(1,1),
Name nvarchar(max) NOT NULL check (len(Name) > 0),
Surname nvarchar(max) NOT NULL check (len(Surname) > 0),
Salary money NOT NULL check(Salary>0)
);

create table Lectures(
Id int primary key identity(1,1),
DayOfWeek int NOT NULL check(DayOfWeek>=1 and DayOfWeek<=7),
LectureRoom nvarchar(max) NOT NULL check(len(LectureRoom)> 0),
SubjectId int foreign key references Subjects,
TeacherId int foreign key references Teachers 
);

create table GroupsLectures(
Id int primary key identity(1,1),
GroupId int foreign key references Groups,
LectureId int foreign key references Lectures
);
go;

-----------------------
insert into Faculties(Name) values(N'Computer Science')
insert into Faculties(Name) values(N'Physics')

insert into Departments(Financing, Name, FacultyId) values(60000, N'Software Development', 1)
insert into Departments(Financing, Name, FacultyId) values(20000, N'Science', 2)

insert into Groups(Name, Year, DepartmentId) values(N'CS602', 3, 1)
insert into Groups(Name, Year, DepartmentId) values(N'P107', 5, 2)

insert into Students(Name, Surname, Age) values(N'Marlyn', N'Carlson', 19)
insert into Students(Name, Surname, Age) values(N'Gregory', N'Castro', 20)
insert into Students(Name, Surname, Age) values(N'Marcelle', N'Dolan', 20)

insert into GroupData(GroupId, StudentId) values (1, 1)
insert into GroupData(GroupId, StudentId) values (1, 3)
insert into GroupData(GroupId, StudentId) values (2, 2)
insert into GroupData(GroupId, StudentId) values (2, 3)

insert into Subjects(Name) values(N'Database Theory')
insert into Subjects(Name) values(N'Electricity')

insert into Teachers(Name, Surname, Salary) values(N'Dave', N'McQueen', N'2000')
insert into Teachers(Name, Surname, Salary) values(N'Jack', N'Underhill', N'3000')

insert into Lectures(DayOfWeek, LectureRoom, SubjectId, TeacherId) values(3, N'D201', 1, 1)
insert into Lectures(DayOfWeek, LectureRoom, SubjectId, TeacherId) values(2, N'D202', 2, 1)
insert into Lectures(DayOfWeek, LectureRoom, SubjectId, TeacherId) values(3, N'D201', 2, 2)

insert into GroupsLectures(LectureId, GroupId) values(1, 1)
insert into GroupsLectures(LectureId, GroupId) values(2, 1)
insert into GroupsLectures(LectureId, GroupId) values(3, 2)
go;
-----------------------

--1--
select count(Teachers.Id) as TeachersNum
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId
where Departments.Name = 'Software Development'
go;

--2--
select count(*) as LecturesNum
from Lectures
inner join Teachers on Teachers.Id = Lectures.TeacherId
where Teachers.Name = 'Dave' and Teachers.Surname = 'McQueen'
go;

--3--
select count(*) as LecturesNum
from Lectures
where LectureRoom = 'D201'
go;

--4--
select Lectures.LectureRoom, count(*) as LecturesNum
from GroupsLectures
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
group by Lectures.LectureRoom
go;

--5--
select count(StudentId) as StudentsNum
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join GroupData on GroupData.GroupId = Groups.Id
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId
where Teachers.Name = 'Jack' and Teachers.Surname = 'Underhill'
go;

--6--
select avg(Teachers.Salary) as AvgSalary
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Teachers on Teachers.Id = Lectures.TeacherId
where Faculties.Name = 'Computer Science'
go;

--7--
select min(GroupQuantity) as MinQuantity, max(GroupQuantity) as MaxQuantity
from (select count(*) as GroupQuantity from GroupData group by GroupId) as GroupCount
go;

--8--
select avg(Financing) as AvgFinancing
from Departments
go;

--9--
select Teachers.Name, Teachers.Surname, count(Subjects.Id) as SubjectsNum
from Lectures
inner join Teachers on Teachers.Id = Lectures.TeacherId
inner join Subjects on Subjects.Id = Lectures.SubjectId
group by Teachers.Name, Teachers.Surname
go;

--10--
select DayOfWeek, count(*) as LecturesNum
from Lectures
group by DayOfWeek
go;

--11-- 
select Lectures.LectureRoom, count(Departments.Id) as DepartmentsNum
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
group by Lectures.LectureRoom
go;

--12-- 
select Faculties.Name, count(Subjects.Id) as SubjectsNum
from GroupsLectures
inner join Groups on Groups.Id = GroupsLectures.GroupId
inner join Departments on Departments.Id = Groups.DepartmentId
inner join Faculties on Faculties.Id = Departments.FacultyId
inner join Lectures on Lectures.Id = GroupsLectures.LectureId
inner join Subjects on Subjects.Id = Lectures.SubjectId
group by Faculties.Name
go;

--13--
select count(*) as LecturesNum
from Lectures
inner join Teachers on Teachers.Id = Lectures.TeacherId
group by LectureRoom, Teachers.Id
go;