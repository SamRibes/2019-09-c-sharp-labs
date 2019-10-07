-- --EXERCISE 1

-- --1.1
-- SELECT * FROM Customers WHERE City LIKE 'london' OR City LIKE 'paris';

-- --1.2
-- SELECT ProductName FROM Products WHERE QuantityPerUnit LIKE '%bottle%';

-- --1.3
-- SELECT ProductName, CompanyName, Country FROM Products 
-- INNER JOIN Suppliers ON Products.ProductID = Suppliers.SupplierID 
-- WHERE QuantityPerUnit LIKE '%bottle%';

-- --1.4
-- SELECT Categories.CategoryName, count(ProductID) AS 'Number of Products by Category'
-- from Products
-- INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
-- GROUP BY Categories.CategoryName
-- ORDER BY 'Number of Products by Category' DESC;

-- --1.5
-- SELECT CONCAT(TitleOfCourtesy, ' ',  FirstName, ' ', LastName) AS 'Name', City FROM Employees;

-- --1.6
-- SELECT RegionDescription, SUM(([Order Details].Quantity*[Order Details].UnitPrice)*(1-[Order Details].Discount)) AS 'Sales Total By Region'
-- FROM Region
-- INNER JOIN Territories on Territories.RegionID = Region.RegionID
-- INNER JOIN EmployeeTerritories on Territories.TerritoryID = EmployeeTerritories.TerritoryID
-- INNER JOIN Orders on EmployeeTerritories.EmployeeID = Orders.EmployeeID
-- INNER JOIN [Order Details] on [Order Details].OrderID = Orders.OrderID
-- GROUP BY RegionDescription
-- HAVING (SUM((Quantity*UnitPrice)*1-Discount) > 1000000);

-- --1.7
-- SELECT COUNT(*) 
-- FROM Orders 
-- WHERE Freight > 100.00
-- AND (ShipCountry = 'UK'
-- OR ShipCountry = 'USA');

-- --1.8
-- SELECT TOP 1 OrderID, SUM((Quantity*UnitPrice)*(Discount)) AS 'Discount Applied'
-- FROM [Order Details]
-- GROUP BY OrderID
-- ORDER BY [Discount Applied] DESC;


-- --EXERCISE 2

-- --2.1
-- CREATE TABLE Spartans(
--     SpartanID int not null identity primary key,
--     SeperateTitle nvarchar(4) NULL,
--     FirstName nvarchar(20) NULL,
--     LastName nvarchar(20) NULL,
--     University nvarchar(30) NULL,
--     CourseTaken nvarchar(30) NULL,
--     MarkAcheived nvarchar(10) NULL,
-- )


-- --EXERCISE 3

-- --3.1
-- SELECT CONCAT(b.FirstName, ' ', b.LastName) as 'Name', CONCAT(a.FirstName, ' ', a.LastName) as 'Reports to'
-- FROM Employees a
-- INNER JOIN Employees b on a.EmployeeID = b.ReportsTo;

-- ------OR!!!!

-- SELECT CONCAT(b.FirstName, ' ', b.LastName) as 'Name', CONCAT(a.FirstName, ' ', a.LastName) as 'Reports to'
-- FROM Employees a, Employees b
-- WHERE b.ReportsTo = a.EmployeeID;

-- --3.2
SELECT Suppliers.CompanyName, 
SUM((Quantity* [Order Details].UnitPrice)*(1-Discount)) as 'Discount Applied' 
FROM Products
INNER JOIN [Order Details] on [Order Details].ProductID = Products.ProductID
INNER JOIN Suppliers on Suppliers.SupplierID = [Products].SupplierID
GROUP BY Suppliers.CompanyName 
HAVING SUM((Quantity* [Order Details].UnitPrice)*(1-Discount)) > 10000
ORDER BY [Discount Applied] DESC

-- --3.3
-- SELECT TOP 10 ContactName, SUM((Quantity*UnitPrice)*1-Discount) as 'Total $ Amount of Orders' FROM Customers
-- INNER JOIN Orders on Orders.CustomerID = Customers.CustomerID
-- INNER JOIN [Order Details] on Orders.OrderID = [Order Details].OrderID
-- GROUP BY ContactName;