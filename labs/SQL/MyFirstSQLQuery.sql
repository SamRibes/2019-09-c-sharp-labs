--select CustomerID, CompanyName, Address, city, region, postalcode, country 
--from customers 
--where city like 'london' or city like 'paris'

--select ProductName from products where QuantityPerUnit like '%bottle%'

--select products.ProductName, Supplier.CompanyName, Suppliers.Country 
--from products 
--inner join Supplier 
--on Products.SupplierID = Suppliers.SupplierID 
--where QuantityPerUnit like '%bottle%'

--SELECT products.ProductName, Suppliers.CompanyName, Suppliers.Country 
--FROM Products 
--INNER JOIN Suppliers ON
--Products.SupplierID = Suppliers.SupplierID 
--where QuantityPerUnit like '%bottle%'

select count(*) as 'Number of Products in Category', Products.CategoryID
from Products
inner join Categories 
on Products.CategoryID = Categories.CategoryID
group by Products.CategoryID