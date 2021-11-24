use EZ 
go

create table User_RobertoC(
Id int identity primary key,
Login nvarchar (255)not null,
Name nvarchar (255)not null,
Email nvarchar (255)not null,
Password nvarchar (255)not null
)


select * from User_RobertoC