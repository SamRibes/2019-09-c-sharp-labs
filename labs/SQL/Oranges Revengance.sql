--Oranges
INSERT INTO Oranges
values ('Dummy', GETDATE(), 0, 2)

select * from Oranges;

DELETE from Oranges
WHERE OrangeName = 'Dummy';

select * from Oranges;

--UPDATE Categories
--set CategoryName = 'Red'
--where CategoryID = 2;