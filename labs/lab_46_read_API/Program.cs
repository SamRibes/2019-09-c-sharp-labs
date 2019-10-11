using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab_46_read_API
{
    class Program
    {
        private static string URL = "https://localhost:44387/api/products";
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            Console.WriteLine($"Can we reach the internet? {IsNetworkLive()}");
            Console.WriteLine();

            GetAPIDataAsync().Wait();
        }

        private static async Task GetAPIDataAsync()
        {
            using (var client = new HttpClient())
            {
                var s = new Stopwatch();
                s.Start();
                //RAW string
                var JSONstring = await client.GetStringAsync(URL);
                //Convert to Object 'Deserialise'
                // USE Newtonsoft
                products = JsonConvert.DeserializeObject<List<Product>>(JSONstring);
                PrintProducts();
                s.Stop();
                Console.WriteLine($"Query took {s.ElapsedMilliseconds} milliseconds");
            }
        }

        private static void PrintProducts()
        {
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductName,-5} {p.UnitPrice}");
            }
        }

        private static bool IsNetworkLive()
        {
            //Do something to check if the network connection is okay first
            //MAny ways to do this.
            //We'll try a ping
            var pingGoogle = new Ping();
            var pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            string data = "abcdefghijklmnopqrstuvwxyz";
            var timeout = 120;
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            //send 4 pings
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Loop {i}\n");
                var reply = pingGoogle.Send("8.8.8.8", timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }
}