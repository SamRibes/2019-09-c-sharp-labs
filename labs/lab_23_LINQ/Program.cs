using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_23_LINQ
{
    class Program
    {
        static List<Customer> customers;
        static void Main(string[] args)
        {
            using(var db= new NorthwindEntities())
            {
                ////LINQ simple Query
                customers = db.Customers.ToList();

                Console.WriteLine("\n\nTrivial LINQ Query \n");

                //This is an abstract type so we cast it to a list
                var output1 =
                    (from Customer in db.Customers
                     select Customer).ToList();

                PrintCustomers(output1);


                ////LINQ Query WHERE city is London OR Berlin
                Console.WriteLine("\n\nLINQ Query WHERE city is London OR Berlin\n");

                var LINQwhere =
                    (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     select customer).ToList();

                PrintCustomers(LINQwhere);



                ////Order by Customer Name
                Console.WriteLine("\n\nOrder by Customer Name \n");

                var LINQOrderBy =
                    (from customer in db.Customers
                     where customer.City == "London"
                     orderby customer.ContactName descending
                     select customer).ToList();
                PrintCustomers(LINQOrderBy);



                ////Lambda has OrderBy ...ThenBy
                Console.WriteLine("\n\nLambda has OrderBy ...ThenBy \n");

                var LINQOrderByThenBy =
                    customers.Where(c => c.City == "London" || c.City == "Berlin" || c.City == "Madrid")
                    .OrderBy(c => c.City)
                    .ThenBy(c => c.ContactName)
                    .ToList();
                PrintCustomers(LINQOrderByThenBy);


                //Creating a Custom output object
                Console.WriteLine("\n\nCreating a Custom output object\n");
                var customObject =
                    from c in db.Customers
                    join order in db.Orders
                    on c.CustomerID equals order.CustomerID
                    select new
                    {
                        Name = c.ContactName,
                        order.OrderID,
                        order.OrderDate,
                        order.ShipCity
                    };

                //manual print

                customObject.ToList().ForEach(item => Console.WriteLine(
                    $"{item.Name,-30} {item.OrderID,-15} {item.OrderDate:dd/MM/yyyy}\t{item.ShipCity,-30}"
                    ));

                //slick print
                db.Orders.ToList().ForEach(item =>
                {
                    //where city is berlin
                    //print customer name, city, orderID, orderDate
                    Console.WriteLine($"{item.Customer.ContactName,-30} {item.OrderID,-15} {item.OrderDate:dd/MM/yyyy}\t{item.Customer.City,-30}");

                });

                //db.order_details.tolist();
                //db.order_details.where(item => item.order.customer.city == "berlin").tolist()
                //    .foreach (o =>
                // {
                //     //where city is berlin
                //     //print customer name, city, orderid, orderdate
                //     console.writeline($"{o.order.customer.contactname,-30} {o.orderid,-15} {o.order.orderdate:dd/mm/yyyy}\t{o.order.customer.city,-15} {o.productid}");

                // }) ;

                //db.Order_Details.ToList();
                //db.Order_Details.Where(item => item.Order.Customer.City == "Berlin").ToList();
                //db.order_details.tolist().foreach (o =>
                // {
                //    //where city is berlin
                //    //print customer name, city, orderid, orderdate
                //    console.writeline($"{o.order.customer.contactname,-30} {o.orderid,-15} {o.order.orderdate:dd/mm/yyyy}\t{o.order.customer.city,-15} {o.productid}");

                //    });

                db.Order_Details.ToList();
                db.Products.ToList();
                db.Orders.ToList();
                db.Order_Details.ToList().ForEach(o =>
                {
                    //where city is berlin
                    //print customer name, city, orderid, orderdate
                    Console.WriteLine($"{o.Order.Customer.ContactName,-30} " +
                        $"{o.OrderID,-15} {o.Order.OrderDate:dd/mm/yyyy}\t" +
                        $"{o.Order.Customer.ContactName,-30} " +
                        $"{o.ProductID, -10}" +
                        $"{o.Product.ProductName}");
                });
                Console.WriteLine();
                Console.ReadLine();
            }

#if DEBUG
           System.Console.WriteLine("We are in debug mode");
            System.Threading.Thread.Sleep(2000);
#endif

        }

#region PrintBlock
       static public void PrintCustomers(List<Customer> listToPrint)
        {
            listToPrint.ForEach(c => Console.WriteLine($"Customer ID: {c.CustomerID,-10} Customer Name: {c.ContactName,-20}  Customer City: {c.City,-35}"));
        }
#endregion PrintBlock
    }
}