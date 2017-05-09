using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentPortal.Models;
using StudentPortal.Models.SeedData;
using StudentPortal.Services.Repository;

namespace StudentPortal {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddLogging();
            // Setting the database context
            services.AddDbContext<SchoolDatabaseContext>();
            // Seed data
            services.AddTransient<ApplicationSeedData>();

            services.AddScoped<ISchoolDatabaseRepository, SchoolDatabaseRepository>();
            // Ading Model View Controller to the project as a service injection
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ApplicationSeedData seeder) {
            

            loggerFactory.AddConsole();

            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(config => {
                config.MapRoute(
                    name: "Default",
                    template: "{Controller}/{Action}/{Id?}",
                    defaults: new { Controller = "Home", Action = "Index" }
                    );
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}
