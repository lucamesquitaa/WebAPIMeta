using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using WebAPIMeta.Models.Context;
using Microsoft.EntityFrameworkCore;
using WebAPIMeta.Repositories.Interfaces;
using WebAPIMeta.Repositories;
using WebAPIMeta.Services.Interfaces;
using WebAPIMeta.Services;

namespace WebAPIMeta
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
            services.AddTransient<IContasService, ContasService>();
            services.AddTransient<ICalculator, Calculator>();

            services.AddDbContext<ContasContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConexaoSqlServer")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Meta API",
                    Version = "v1",
                    Description = "Desafio Meta Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Luca Albuquerque",
                        Email = string.Empty
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meta API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
