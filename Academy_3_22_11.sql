create database Academy;
use Academy;
go;

create table People(
[Id] int primary key identity(1, 1),
[Name] nvarchar(30) NOT NULL,
[Surname] nvarchar(30) NOT NULL,
[Age] int NOT NULL check (Age >= 14 and Age < 100)
);

create table Employees(
[Id] int primary key identity(1, 1),
[Salary] smallmoney NOT NULL check ([Salary] >= 300),
[Experience] int NOT NULL check ([Experience] >= 0)
);

create table Teachers(
[Id] int primary key identity(1, 1),
[PersonId] int foreign key references People(Id),
[EmployeeId] int foreign key references Employees(Id)
);

create table Students(
[Id] int primary key identity(1, 1),
[PersonId] int foreign key references People(Id)
);

create table Faculties(
[Id] int primary key identity(1, 1),
[Name] nvarchar(30) NOT NULL
);

create table Groups(
[Id] int primary key identity(1, 1),
[Name] nvarchar(30) NOT NULL,
[Course] int NOT NULL check ([Course] >= 1 and [Course] <= 6),
[FacultyId] int foreign key references Faculties(Id)
);

create table GroupData(
[Id] int primary key identity(1,1),
[StudentId] int foreign key references Students(Id),
[GroupId] int foreign key references Groups(Id),
);

create table StudyPlan(
[Id] int primary key identity(1,1),
[TeacherId] int foreign key references Teachers(Id),
[GroupId] int foreign key references Groups(Id),
);
go;

insert into Faculties(Name) values (N'IT');
insert into Groups(Name, Course, FacultyId) values ('FBAS_3_22_11_ru', 3, 1);

insert into People(Name, Surname, Age) values(N'Elvin', N'Azimov', 22);
insert into Employees(Salary, Experience) values(3000, 6);
insert into Teachers(PersonId, EmployeeId) values(1, 1);

insert into StudyPlan(Teacherid, Groupid)  values(1, 1);

insert into People(Name, Surname, Age) values(N'Gariba', N'Dadashova', 19);
insert into People(Name, Surname, Age) values(N'Alina', N'Orujova', 15);
insert into People(Name, Surname, Age) values(N'Tatyana', N'Ermakova', 23);
insert into People(Name, Surname, Age) values(N'Yusif', N'Bayramov', 22);
insert into People(Name, Surname, Age) values(N'Magomed', N'Farmanov', 23);
insert into People(Name, Surname, Age) values(N'Vagif', N'Aliyev', 15);
insert into People(Name, Surname, Age) values(N'Bahtiyar', N'Mirzoyev', 17);
insert into People(Name, Surname, Age) values(N'Anver', N'Mammadov', 19);
insert into People(Name, Surname, Age) values(N'Yusif', N'Melikov', 15);
insert into People(Name, Surname, Age) values(N'Xelil', N'Orujlu', 15);
insert into People(Name, Surname, Age) values(N'Afgan', N'Maksudlu', 15);
insert into People(Name, Surname, Age) values(N'Murad', N'Efendiyev', 15);
insert into People(Name, Surname, Age) values(N'Nilay', N'Aliyeva', 15);
insert into People(Name, Surname, Age) values(N'Eldeniz', N'Yolchuyev', 19)

insert into Students(PersonId) values(2);
insert into Students(PersonId) values(3);
insert into Students(PersonId) values(4);
insert into Students(PersonId) values(5);
insert into Students(PersonId) values(6);
insert into Students(PersonId) values(7);
insert into Students(PersonId) values(8);
insert into Students(PersonId) values(9);
insert into Students(PersonId) values(10);
insert into Students(PersonId) values(11);
insert into Students(PersonId) values(12);
insert into Students(PersonId) values(13);
insert into Students(PersonId) values(14);
insert into Students(PersonId) values(15);

insert into GroupData(Studentid, Groupid) values(1, 1);
insert into GroupData(Studentid, Groupid) values(2, 1);
insert into GroupData(Studentid, Groupid) values(3, 1);
insert into GroupData(Studentid, Groupid) values(4, 1);
insert into GroupData(Studentid, Groupid) values(5, 1);
insert into GroupData(Studentid, Groupid) values(6, 1);
insert into GroupData(Studentid, Groupid) values(7, 1);
insert into GroupData(Studentid, Groupid) values(8, 1);
insert into GroupData(Studentid, Groupid) values(9, 1);
insert into GroupData(Studentid, Groupid) values(10, 1);
insert into GroupData(Studentid, Groupid) values(11, 1);
insert into GroupData(Studentid, Groupid) values(12, 1);
insert into GroupData(Studentid, Groupid) values(13, 1);
insert into GroupData(Studentid, Groupid) values(14, 1);
go;

select People.Name, People.Surname, Groups.Name
from GroupData
inner join Students on GroupData.StudentId = Students.Id
inner join People on Students.PersonId = People.Id
inner join Groups on Groups.Id = GroupData.GroupId;
go;

select People.Name, People.Surname, Employees.Experience, Groups.Name
from StudyPlan
inner join Groups on StudyPlan.GroupId = Groups.Id
inner join Teachers on StudyPlan.TeacherId = Teachers.Id
inner join Employees on Teachers.EmployeeId = Employees.Id
inner join People on Teachers.PersonId = People.Id;
go;

alter table Students
add [GPA] int check([GPA]>=1 and [GPA]<=12);
go;

update Students
set [GPA] = 11;
go;

select People.Name, People.Surname, Students.GPA, Groups.Name
from GroupData
inner join Students on GroupData.StudentId = Students.Id
inner join People on Students.PersonId = People.Id
inner join Groups on Groups.Id = GroupData.GroupId;
go;