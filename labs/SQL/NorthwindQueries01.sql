--Northwind

--select top 5 * from Customers ORDER BY CustomerID DESC;

--SELECT * FROM Products 
--WHERE UnitsInStock < 10 
--	AND Discontinued = 0 
--ORDER BY UnitsInStock 
--DESC

--UPDATE Products 
--SET UnitsInStock = 200
--WHERE ProductID = 31;

--SELECT * FROM Products 
--WHERE UnitsInStock < 10 
--	AND Discontinued = 0 
--ORDER BY UnitsInStock 
--DESC

--SELECT * FROM Products WHERE ProductID = 31;

--SELECT country FROM Customers ORDER BY country
--SELECT distinct country FROM Customers ORDER BY country


--SELECT * FROM Products WHERE ProductName LIKE '%ch%';
--SELECT * FROM Products WHERE ProductName NOT LIKE '%ch%';
--SELECT * FROM products where unitprice between 10 and 20 order by UnitPrice asc;


--SELECT count(city) as 'Number of Cities' from Customers

--SELECT AVG(UnitPrice) as 'Average Price', MIN(UnitPrice)as 'Minimum Price', MAX(UnitPrice) as 'Maximum Price' from Products


-- SELECT ProductName, UnitPrice FROM products;

-- SELECT sum(unitprice*quantity) FROM [Order Details];

-- SELECT sum(unitprice*quantity * (1-discount)) as 'Discounted Sales' FROM [Order Details];

-- SELECT sum(unitprice*quantity) as 'Gross Sales', 
-- sum(unitprice*quantity * (1-discount)) as 'Discounted Sales', 
-- sum(unitprice*quantity*discount) as 'Discount Given' 
-- FROM [Order Details];


-- SELECT supplierid, sum(unitsonorder) as 'Total Units on Order' from Products
-- group by SupplierID
-- HAVING sum(UnitsOnOrder) = 0
-- order by [Total Units on Order] desc;

-- SELECT supplierid, sum(unitsonorder) as 'Total Units on Order' from Products
-- GROUP BY SupplierID
-- HAVING sum(UnitsOnOrder) > 0
-- ORDER BY [Total Units on Order]

-- SELECT supplierid, sum(unitsonorder) as 'Total Units on Order' from Products
-- GROUP BY SupplierID
-- HAVING sum(UnitsOnOrder) > 0
-- ORDER BY [Total Units on Order]

-- --sub queries

-- SELECT * FROM Customers WHERE CustomerID not in 
-- (SELECT CustomerID from Orders)


SELECT * FROM Customers;