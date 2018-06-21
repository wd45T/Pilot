using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pilot.DataCore;
using Pilot.Repository.Implementations;
using Pilot.Repository.Interfaces;
using Pilot.Repository.Mappings;

namespace Pilot
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            ConnectionString = Configuration.GetConnectionString("Pilot");
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder
                        .WithOrigins("http://localhost:3001", "http://localhost:3001/")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()); // при AllowAnyOrigin нельзя AllowCredentials
            });

            services.AddTransient(sp => new DataManager(ConnectionString));
            services.AddTransient<Func<DataManager>>(_ => () => new DataManager(ConnectionString));
            services.AddTransient<Func<SqlConnection>>(_ => () => new SqlConnection(ConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();


            services.AddAutoMapper(_ => _.AddProfiles(typeof(DomainProfile)));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
