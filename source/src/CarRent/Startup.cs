using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Application.Mapper;
using CarRent.Common.Application;
using CarRent.Common.Infrastructure;
using CarRent.Connection;
using CarRent.CustomerManagement.Application;
using CarRent.CustomerManagement.Application.Mapper;
using CarRent.InvoiceManagement.Application;
using CarRent.InvoiceManagement.Application.Mapper;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Application.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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
            Task.Run(async () =>
            {
                var settings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                await DB.InitAsync(settings.DatabaseName, settings.HostAddress, settings.Port);
                await DB.MigrateAsync();
            }).GetAwaiter().GetResult();

            services.AddControllers();

            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CarRent.API", Version = "v1"});
            });
            services.AddScoped<IBrandMapper, BrandMapper>();
            services.AddScoped<ICarMapper, CarMapper>();
            services.AddScoped<ICarClassMapper, CarClassMapper>();
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<IReservationMapper, ReservationMapper>();
            services.AddScoped<IInvoiceMapper, InvoiceMapper>();

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICarClassService, CarClassService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}