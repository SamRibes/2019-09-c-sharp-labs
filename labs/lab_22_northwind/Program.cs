using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_22_northwind
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products;

            using (var db = new NorthwindEntities())
            {
                products = db.Products.ToList();
                db.Categories.ToList();
                db.Suppliers.ToList();
            }

            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product ID: {p.ProductID,-10}Product Name: {p.ProductName,-35}Product Price: {p.UnitPrice,-10}");
            //}

            //foreach (var c in categories)
            //{
            //    Console.WriteLine($"Category ID: {c.CategoryID,-10}Category Name: {c.CategoryName,-35}Category Description: {c.Description,-10}");
            //}


            foreach (var p in products)
            {
                Console.WriteLine($"Product ID: {p.ProductID,-10} Product Name: {p.ProductName,-35} Supplier Name: {p.Supplier.CompanyName,-40} Category Name: {p.Category.CategoryName, -35} Product Price: {p.UnitPrice,-10}");
            }

            Console.ReadLine();
        }
    }
}
