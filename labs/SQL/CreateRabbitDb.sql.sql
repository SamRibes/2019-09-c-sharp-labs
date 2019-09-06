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

--CREATE TABLE Rabbits(
--	RabbitID INT NOT NULL IDENTITY PRIMARY KEY,
--	Age INT,
--	Name NVARCHAR(50) NULL
--);


update Rabbits set Age = 99 where RabbitID = 5;

delete from rabbits;

SET IDENTITY_INSERT rabbits on
insert into rabbits (rabbitid, age, name) values (1,0,'rabbits01')
SET IDENTITY_INSERT rabbits on

select * from Rabbits;