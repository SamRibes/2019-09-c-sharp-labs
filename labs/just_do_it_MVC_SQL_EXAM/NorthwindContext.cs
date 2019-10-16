﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace just_do_it_MVC_SQL_EXAM
{
    class NorthwindContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Region> Regions { get; set; }
        //public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        //public DbSet<Territory> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Northwind;Integrated Security=True");
        }
    }
}
