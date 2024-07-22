use master;
create database TaskManagementDB;
use TaskManagementDB;
go;

create table Tasks (
    Id int primary key identity (1,1),
    Name nvarchar(50) not null default 'New task',
    Description nvarchar(100),
    Deadline date not null default current_timestamp,
);
go;

/*dotnet ef dbcontext scaffold "Server=localhost;Database=TaskManagementDB;User Id=admin;Password=admin;Trust Server Certificate=true;" Microsoft.EntityFrameworkCore.SqlServer
*/

insert into Tasks (Name, Description, Deadline)
    values
    ('First Task', 'Description for first task', '2024-07-31'),
('Second Task', 'Description for second task', '2024-08-15'),
('Third Task', 'Description for third task', '2024-08-01');

insert into Tasks (Description)
    values ('Description for fourth task');
go;