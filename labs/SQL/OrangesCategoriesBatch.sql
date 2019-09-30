--create table Categories(
--CategoryID int not null Identity Primary Key,
--CategoryName nvarchar(50) null
--)
--go

--create table Oranges(
--OrangeID int not null Identity Primary Key,
--OrangeName nvarchar(50) null, 
--DateHarvested Date null,
--IsLuxuryGrade Bit null,
--CategoryID int null Foreign key references Categories(CategoryID)
--)
--go

--create  table Batch(
--	BatchID int not null identity primary key,
--	OrangeID int null foreign key references Oranges(OrangeID),
--	Quantity int null,
--	DispatchDate Date null
--)
--go


--insert into Oranges values ('Clementine', '2018-12-25', 0 , 2)
--insert into Oranges values ('Blood Orange', '2018-12-25', 0 , 1)
--insert into Oranges values ('Tangerine', '2018-12-25', 1 , 3)
--go

--select * from Oranges
--select * from Categories
--go

--select OrangeID,OrangeName,CategoryName from Oranges
--inner join Categories on Oranges.CategoryID = CAtegories.CategoryID;
--go

--select OrangeID, OrangeName, CategoryName, DateHarvested, dateadd(DAY,90,DateHarvested) as 'ExpiryDate' from Oranges
--	inner join Categories on Oranges.CategoryID = CAtegories.CategoryID;
--go

select *, DATEDIFF(d, Oranges.DateHarvested, GETDATE()) as SinceHarvested,
case
	when DATEDIFF(d, Oranges.DateHarvested, GETDATE()) > 90 
	then 'true'
	else 'false' 
	end
as IsExpired
from batch
inner join Oranges on oranges.OrangeID = Batch.OrangeID;