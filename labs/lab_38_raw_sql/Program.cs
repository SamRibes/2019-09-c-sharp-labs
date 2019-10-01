using System;
using System.Data.Sql;
using System.Data.SqlClient;

namespace lab_38_raw_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost; Initial Catalog=Northwind; Persist Security Info=True; User ID=SA; Password=Passw0rd2018";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }

            string connectionString2 = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);

                string sqlQuery01 = "select * from Customers";

                using (var sqlCommand = new SqlCommand(sqlQuery01, connection2))
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var City = reader["City"].ToString();
                        var Country= reader["Country"].ToString();
                        var CompanyName = reader["CustomerID"].ToString();

                        var customer = new Customer();
                    }
                }
            }
        }

        public partial class Customer
        {
            Customer()
            {

            }
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
        }
    }
}
