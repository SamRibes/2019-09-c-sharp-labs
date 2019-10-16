using System;
using System.Collections.Generic;
using System.Linq;

namespace just_do_it_SQL_EXAM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                Exercise1(context);
                Console.WriteLine();
                Exercise2(context);
                Console.WriteLine();
                Exercise3(context);
            }
        }

        static void Exercise1(NorthwindContext context)
        {
            var customers = context.Customers
                .Where(c => c.City.Contains("London") || c.City.Contains("Paris"))
                .ToList();

            foreach(var c in customers)
            {
                Console.WriteLine($"Customer Name = {c.ContactName, -20} City = {c.City}");
            }
        }

        static void Exercise2(NorthwindContext context)
        {
            //SELECT ProductName FROM Products WHERE QuantityPerUnit LIKE '%bottle%';
            var products = context.Products
                .Where(p => p.QuantityPerUnit.Contains("bottle"))
                .ToList();

            foreach (var p in products)
            {
                Console.WriteLine($"Product Name = {p.ProductName}");
            }
        }

        static void Exercise3(NorthwindContext context)
        {
            //SELECT ProductName, CompanyName, Country FROM Products
            //INNER JOIN Suppliers ON Products.ProductID = Suppliers.SupplierID
            //WHERE QuantityPerUnit LIKE '%bottle%';

            List<ProductSupplier> items = context.Products
                .Join(context.Suppliers, product => product.SupplierID, supplier => supplier.SupplierID,
                (product, supplier) => new { product, supplier })
                .Where(productsupplier => productsupplier.product.QuantityPerUnit.Contains("bottle"))
                .Select(listToReturn => new ProductSupplier { ProductName = listToReturn.product.ProductName, CompanyName = listToReturn.supplier.CompanyName, Country = listToReturn.supplier.Country })
            //.Select(listToReturn => new ProductSupplier{ Product = listToReturn.product, Supplier = listToReturn.Supplier })
            //Use this if you have set up model using other models instead of indivual columns
                .ToList();

            //var items = (from p in context.Products
            //             where p.QuantityPerUnit.Contains("bottle")
            //             join s in context.Suppliers on p.SupplierID equals s.SupplierID
            //             select new ProductSupplier() { ProductName = p.ProductName, CompanyName = s.CompanyName, Country = s.Country})
            //             //select new { p.ProductName, s.CompanyName, s.Country })
            //             .ToList();

            foreach (var p in items)
            {
                Console.WriteLine($"Product Name = {p.ProductName}, Supplier Name = {p.CompanyName}, Supplier Country = {p.Country}");
            }
        }
    }
}