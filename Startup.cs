using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using toDoList_project.Model;

namespace toDoList_project
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApplication1DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //services.AddDbContext<MyContext>(o => o.UseSqlServer(conString));
            // Add support for controllers and views
            services.AddControllersWithViews();

            // Register CustomersService for DI
            services.AddSingleton<TodoService>();
            services.AddTransient<CalenderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Are we in development?
            if (env.IsDevelopment())
            {
                // Then show detailed error messages
                app.UseDeveloperExceptionPage();
            }

            // Map url:s to actions in our controllers 
            // "" -> CustomersController.Index
            // "create" -> CustomersController.Create
            app.UseRouting();

            // Map routes to controllers
            app.UseEndpoints(o => o.MapControllers());

            app.UseStaticFiles();
        }
    }
}
