using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditorAPI.Domain;
using AuditorAPI.EventConsumers;
using AuditorAPI.Services;
using AuditorAPI.UnitOfWork;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AuditorAPI
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
            services.AddDbContext<AuditDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));
            services.AddMassTransit(x =>
            {
                x.AddConsumer<AuditorProfileEventConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host("rabbitmq://localhost");
                    config.ReceiveEndpoint("Auditor-Topic", endpoint =>
                    {
                        endpoint.PrefetchCount = 10;
                        endpoint.ConfigureConsumer<AuditorProfileEventConsumer>(provider);
                    });
                }));
            });

            services.AddMassTransitHostedService();
            services.AddControllers();
         
            services.AddScoped<IUnitOfWork, AuditorAPI.UnitOfWork.UnitOfWork>();
            services.AddSingleton<IRepository<AuditPortfolio>, AuditPortfolioRepository>();
            services.AddScoped<AuditorAPI.Services.IAuditPortfolioService, AuditPortfolioService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
