--EXERCISE 1

--1.1

--select * from Customers where City Like 'london' or city like 'paris';

--1.2
-- select ProductName from Products where QuantityPerUnit like '%bottle%';

--1.3
-- select ProductName, CompanyName, Country from Products 
-- INNER JOIN Suppliers on Products.ProductID = Suppliers.SupplierID 
-- where QuantityPerUnit like '%bottle%';

--1.4
-- SELECT Categories.CategoryName, count(ProductID) as 'Number of Products by Category'
-- from Products
-- INNER JOIN Categories on Products.CategoryID = Categories.CategoryID
-- GROUP BY Categories.CategoryName
-- ORDER BY 'Number of Products by Category' DESC;

--1.5
-- SELECT CONCAT(TitleOfCourtesy, ' ',  FirstName, ' ', LastName) as 'Name', City FROM Employees;

--1.6
-- SELECT RegionDescription, ROUND((SUM((Quantity*UnitPrice)*1-Discount)), 2) as 'Sales Total By Region'
-- FROM Region
-- INNER JOIN Territories on Territories.RegionID = Region.RegionID
-- INNER JOIN EmployeeTerritories on Territories.TerritoryID = EmployeeTerritories.TerritoryID
-- INNER JOIN Orders on EmployeeTerritories.EmployeeID = Orders.EmployeeID
-- INNER JOIN [Order Details] on [Order Details].OrderID = Orders.OrderID
-- GROUP BY RegionDescription
-- HAVING (SUM((Quantity*UnitPrice)*1-Discount) > 1000000);

--1.7
-- SELECT COUNT(*) 
-- FROM Orders 
-- WHERE Freight > 100.00
-- AND (ShipCountry = 'UK'
-- OR ShipCountry = 'USA');

--1.8
-- SELECT TOP 1 OrderID, SUM((Quantity*UnitPrice)*(Discount)) as 'Discount Applied'
-- FROM [Order Details]
-- GROUP BY OrderID
-- ORDER BY [Discount Applied] DESC;


--EXERCISE 2

--2.1
-- CREATE TABLE Spartans(
--     SpartanID int not null identity primary key,
--     SeperateTitle nvarchar(4) NULL,
--     FirstName nvarchar(20) NULL,
--     LastName nvarchar(20) NULL,
--     University nvarchar(30) NULL,
--     CourseTaken nvarchar(30) NULL,
--     MarkAcheived nvarchar(10) NULL,
-- )

--EXERCISE 3

--3.1
-- SELECT CONCAT(b.FirstName, ' ', b.LastName) as 'Name', CONCAT(a.FirstName, ' ', a.LastName) as 'Reports to'
-- FROM Employees a
-- INNER JOIN Employees b on a.EmployeeID = b.ReportsTo;

------OR!!!!

-- SELECT CONCAT(b.FirstName, ' ', b.LastName) as 'Name', CONCAT(a.FirstName, ' ', a.LastName) as 'Reports to'
-- FROM Employees a, Employees b
-- WHERE b.ReportsTo = a.EmployeeID;

--3.2
SELECT * FROM Products
INNER JOIN [Order Details] on [Order Details].ProductID = Products.ProductID
INNER JOIN Suppliers on SUppliers.SupplierID = [Order Details].SupplierID;


--3.3
-- SELECT SUM((Quantity*UnitPrice)*1-Discount) as 'Total $ Amount of Orders', ContactName FROM Customers
-- INNER JOIN Orders on Customers.CustomerID = Orders.CustomerID
-- INNER JOIN [Order Details] on Orders.OrderID = [Order Details].OrderID;