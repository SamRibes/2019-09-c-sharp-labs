use master
go

drop database if exists RabbitDb
go

create database RabbitDb
go

use RabbitDb
go

CREATE TABLE Categories(
	CategoryID int not null identity primary key,
	CategoryName nvarchar(50) null
);

CREATE TABLE Rabbits(
	RabbitID int not null identity primary key,
	RabbitName nvarchar(50) null,
	Age int null,
	CategoryId int null foreign key (CategoryId) references Categories(CategoryId)
);

insert into Categories values ('white');
insert into Categories values ('black');
insert into Categories values ('pink');

update Rabbits set CategoryId = 3 where RabbitID = 1;

select * from Rabbits;
select * from Categories;