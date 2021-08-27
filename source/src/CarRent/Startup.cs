using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Mapper;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.Connection;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Application.Mapper;
using Microsoft.Extensions.Options;
using MongoDB.Entities;

namespace CarRent
{
    [ExcludeFromCodeCoverage]
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
            Task.Run(async () => {
                    var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                    await DB.InitAsync(settings.DatabaseName, settings.HostAddress, settings.Port);
                    await DB.MigrateAsync();
            }).GetAwaiter().GetResult();

            services.AddControllers();

            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRent.API", Version = "v1" });
            });
            services.AddScoped<IBrandServiceMapper, BrandServiceMapper>();
            services.AddScoped<ICarServiceMapper, CarServiceMapper>();
            services.AddScoped<ICarClassServiceMapper, CarClassServiceMapper>();
            services.AddScoped<ICustomerMapper, CustomerMapper>();


            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICarClassService, CarClassService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRent.API v1"));
            }

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
