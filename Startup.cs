using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;

using Services;
using Services.Implementations;
using Model.Context;

namespace webapi01
{
    public class Startup
    {
        //Construtor Startup
        public Startup(IConfiguration configuration){
            this.Configuration = configuration;
        }//END consructor

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>( options => options.UseMySql( connection ) );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Injeção de dependência
            services.AddScoped<IPersonService, PersonServiceImpl>();
            services.AddApiVersioning();
        }//END ConfigureServices()

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
}
