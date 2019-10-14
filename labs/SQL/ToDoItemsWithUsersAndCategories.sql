use master
go

drop database if exists ToDoItemsDatabase
go

create database ToDoItemsDatabase
go

use ToDoItemsDatabase
go

create table Categories(
	CategoryID INT NOT NULL IDENTITY PRIMARY KEY,
	CategoryName varchar(50),
	CategoryDescription varchar(50) NULL
);


create table ToDoItems(
	ToDoItemId INT NOT NULL IDENTITY PRIMARY KEY,
	Item VarChar(50) NULL,
	DateDue DATE NULL,
	Done BIT NULL
);

create table Users(
	UserID INT NOT NULL IDENTITY PRIMARY KEY,
	UserName varchar(50),
	ToDoItemID INT NULL FOREIGN KEY REFERENCES ToDoItems(ToDoItemID),
	CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID)
);

INSERT INTO Categories VALUES ('Category Name 1', 'Category Description');
INSERT INTO Categories VALUES ('Category Name 2', 'Category Description');
INSERT INTO Categories VALUES ('Category Name 3', 'Category Description');
INSERT INTO Categories VALUES ('Category Name 4', 'Category Description');


INSERT INTO ToDoItems VALUES ('To Do Item 1', GETDATE(), 0);
INSERT INTO ToDoItems VALUES ('To Do Item 2', GETDATE(), 1);
INSERT INTO ToDoItems VALUES ('To Do Item 3', GETDATE(), 0);
INSERT INTO ToDoItems VALUES ('To Do Item 4', GETDATE(), 1);


INSERT INTO Users VALUES ('User Name 1', 1, 1);
INSERT INTO Users VALUES ('User Name 2', 2, 2);
INSERT INTO Users VALUES ('User Name 3', 3, 3);
INSERT INTO Users VALUES ('User Name 4', 4, 4);

SELECT * FROM Users;
SELECT * FROM Categories;
SELECT * FROM ToDoItems;