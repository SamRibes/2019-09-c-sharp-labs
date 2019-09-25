using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab_34_API_Northwind.Controllers
{
    public class FullCustomerController : ApiController
    {
        public static List<Customer> customers;

        public List<Customer> GetCustomerNames()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }
            return customers;
        }
    }
}
