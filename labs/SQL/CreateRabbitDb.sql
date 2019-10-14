--use master
--go

--drop database if exists RabbitDb
--go

--create database RabbitDb
--go

--use RabbitDb
--go

--select 'Here is a comment'

--use RabbitDb
--go

CREATE TABLE Rabbits(
	RabbitID INT NOT NULL IDENTITY PRIMARY KEY,
	Age INT,
	Name NVARCHAR(50) NULL
);

insert into rabbits (age, name) values (0,'rabbits01')