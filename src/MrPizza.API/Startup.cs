using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MrPuzza.Domain.Infra.Contexts;

namespace MrPizza
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
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddMvc()
                .AddFluentValidation();
            services.AddCors();
            services.AddDbContext<MrPizzaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            //services.AddTransient<IClientRepository, ClienteRepository>();
            services.AddSwaggerGen();
            //services.AddMediatR(typeof(NewClienteCommand).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MrPizza V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var dbContextAccount = serviceScope.ServiceProvider.GetRequiredService<MrPizzaContext>();
                dbContextAccount.Database.Migrate();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
