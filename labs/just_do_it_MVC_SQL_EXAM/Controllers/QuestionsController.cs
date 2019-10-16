using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace just_do_it_MVC_SQL_EXAM.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Question1()
        {
            List<Customer> customers = new List<Customer>();
            using (var db = new NorthwindContext())
            {
                customers = db.Customers
                .Where(c => c.City.Contains("London") || c.City.Contains("Paris"))
                .ToList();
            }
            ViewBag.customers = customers;
            return View(customers);
        }

        public IActionResult Question2()
        {
            List<Product> products = new List<Product>();
            using (var db = new NorthwindContext())
            {
                products = db.Products
                .Where(p => p.QuantityPerUnit.Contains("bottle"))
                .ToList();
            }
            ViewBag.products = products;
            return View(products);
        }

        public IActionResult Question3()
        {
            List<ProductSupplier> items = new List<ProductSupplier>();
            using (var db = new NorthwindContext())
            {
                items = db.Products
                .Join(db.Suppliers, product => product.SupplierID, supplier => supplier.SupplierID,
                (product, supplier) => new { product, supplier })
                .Where(productsupplier => productsupplier.product.QuantityPerUnit.Contains("bottle"))
                .Select(listToReturn => new ProductSupplier { ProductName = listToReturn.product.ProductName, CompanyName = listToReturn.supplier.CompanyName, Country = listToReturn.supplier.Country })
                .ToList();
            }
            ViewBag.items = items;
            return View(items);
        }
    }
}