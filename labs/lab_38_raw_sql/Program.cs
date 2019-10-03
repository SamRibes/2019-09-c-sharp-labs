using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;

namespace lab_38_raw_sql
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static string connectionString = $@"Data Source=localhost; Initial Catalog=Northwind; Persist Security Info=True; User ID=SA; Password={Environment.GetEnvironmentVariable("DBPassword")}";
        static string connectionString2 = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind;";

        static void Main(string[] args)
        {

            //UpdateCustomer();

            //InsertCustomer();

            //Console.WriteLine(GenerateRandomID());

            //DeleteCustomer();
            
            GetCustomers();
        }


        static void GetCustomers()
        {
            Console.WriteLine("Reading all Customers");

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                Console.WriteLine($"Connection to database is {connection2.State}");

                string sqlQuery01 = "select * from Customers";

                using (var sqlCommand = new SqlCommand(sqlQuery01, connection2))
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();
                        var CompanyName = reader["CustomerID"].ToString();

                        var customer = new Customer(CustomerID, ContactName, City, Country, CompanyName);
                        customers.Add(customer);
                    }
                }
            }

            customers.ForEach(customer => Console.WriteLine($"{customer.CustomerID,-10} {customer.ContactName,-25} {customer.CompanyName,-20} {customer.City}"));

            Console.WriteLine($"There are {customers.Count} customers in the database.");
        }

        static void InsertCustomer()
        {
            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                Console.WriteLine($"Connection to database is {connection2.State}");

                var FixedCustomer = new Customer("1", "Sam", "SamInc", "London", "England");
                string sqlQuery01 = $"INSERT INTO Customers (CustomerID, ContactName, CompanyName, City, Country) " +
                    $"VALUES ('{GenerateRandomID()}', '{FixedCustomer.ContactName}', '{FixedCustomer.CompanyName}', '{FixedCustomer.City}', '{FixedCustomer.Country}')";

                using (var sqlCommand = new SqlCommand(sqlQuery01, connection2))
                {
                    int affected = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"{affected} rows inserted.");
                }

                //insert using parameters
                //use paramters when taking values from e.g. form on screen
                var randomID = GenerateRandomID();

                Console.WriteLine($"New ID is {randomID}");
                FixedCustomer = new Customer(randomID, "Sam", "SamInc", "London", "England");

                var insertWithParameters = new SqlCommand("INSERT INTO Customers (CustomerID, ContactName, CompanyName, City, Country) " +
                    "VALUES (@CustomerID, @ContactName, @CompanyName, @City, @Country)", connection2);

                insertWithParameters.Parameters.AddWithValue("@CustomerID", randomID);
                insertWithParameters.Parameters.AddWithValue("@ContactName", "Sam");
                insertWithParameters.Parameters.AddWithValue("@CompanyName", "SpartaGlobal");
                insertWithParameters.Parameters.AddWithValue("@City", "London");
                insertWithParameters.Parameters.AddWithValue("@Country", "UK");

            }

        }

        static void UpdateCustomer()
        {
            var customerID = "'ALFKI'";
            var sqlUpdate = $"UPDATE Customers SET City='Paris' WHERE CustomerID = {customerID}";

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                using (var sqlCommand = new SqlCommand(sqlUpdate, connection2))
                {
                    int affected = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records updated : {affected}");
                }
            }
                
        }

        static void DeleteCustomer()
        {
            var customerID = "'sam3'";
            var sqlDelete = $"DELETE Customers WHERE CustomerID = {customerID}";

            using (var connection2 = new SqlConnection(connectionString2))
            {
                connection2.Open();
                using (var sqlCommand = new SqlCommand(sqlDelete, connection2))
                {
                    int affected = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records updated : {affected}");
                }
            }
        }

        static string GenerateRandomID()
        {
            //Random rand

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var charsAndNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                if (i == 0)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                else
                {
                    stringChars[i] = charsAndNumbers[random.Next(charsAndNumbers.Length)];
                }
               
            }

            var finalString = (new String(stringChars));

            return finalString;
        }
    }

    public partial class Customer
    {
        public Customer(string CustomerID, string ContactName, string CompanyName, string City, String Country)
        {
            this.CustomerID = CustomerID;
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
            this.City = City;
            this.Country = Country;
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
