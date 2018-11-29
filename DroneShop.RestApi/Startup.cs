using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Droneshop.Core.ApplicationService;
using Droneshop.Core.ApplicationService.Services;
using Droneshop.Core.DomainService;
using Droneshop.Data;
using Droneshop.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DroneShop.RestApi
{
    public class Startup
    {
        private IConfiguration _conf { get; }
        private IHostingEnvironment _env { get; set; }
        
        public Startup(IConfiguration conf, IHostingEnvironment env)
        {
            _conf = conf;
            _env = env;
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (_env.IsDevelopment())
            {
                services.AddDbContext<DroneShopContext>(
                    opt => opt.UseSqlite("Data Source=DroneShop.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<DroneShopContext>(
                    opt => opt.UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }
            
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IDroneService, DroneService>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<DroneShopContext>();
                    
                    DBInitializor.SeedDB(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
