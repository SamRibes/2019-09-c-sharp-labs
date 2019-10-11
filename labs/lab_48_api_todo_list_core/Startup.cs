using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace lab_48_api_todo_list_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaskItemContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class TaskItem
    {
        public int TaskItemID { get; set; }
        [Required]
        public string Description { get; set; }
        public bool TaskDone { get; set; }
        [Display(Name = "Date Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateDue { get; set; }

        public int? UserID { get; set; }
        public User User { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
    }
    
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        public int? TaskItemID { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }


    public class TaskItemContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserID = 1, Username = "User's name here"},
                new User() { UserID = 2, Username = "User's name here"},
                new User() { UserID = 3, Username = "User's name here"},
                new User() { UserID = 4, Username = "User's name here"}
                );
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem() { TaskItemID = 1, Description = "Description Here", DateDue = DateTime.Parse("11/10/2019"), TaskDone = true, UserID = 1, CategoryID = 3 },
                new TaskItem() { TaskItemID = 2, Description = "Description Here", DateDue = DateTime.Parse("11/10/2019"), TaskDone = true, UserID = 1, CategoryID = 3 },
                new TaskItem() { TaskItemID = 3, Description = "Description Here", DateDue = DateTime.Parse("11/10/2019"), TaskDone = true, UserID = 1, CategoryID = 3 },
                new TaskItem() { TaskItemID = 4, Description = "Description Here", DateDue = DateTime.Parse("11/10/2019"), TaskDone = true, UserID = 1, CategoryID = 3 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, CategoryName = "Cat Name Here", Description = "Description Here"},
                new Category() { CategoryID = 2, CategoryName = "Cat Name Here", Description = "Description Here"},
                new Category() { CategoryID = 3, CategoryName = "Cat Name Here", Description = "Description Here"},
                new Category() { CategoryID = 4, CategoryName = "Cat Name Here", Description = "Description Here"}
            );


        }
        private static bool _dbCreated = false;
        public TaskItemContext()
        {
            if(!_dbCreated)
            {
                _dbCreated = true;
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
                Console.WriteLine("Test data to console");
                Trace.WriteLine("Test Data to output window");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(@"Data Source=ToDoDatabase.db;");
        }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }


}
