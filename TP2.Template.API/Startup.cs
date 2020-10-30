using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqlKata.Compilers;
using TP.Template.AccessData;
using TP.Template.AccessData.Commands;
using TP2.Template.AccessData.Queries;
using TP2.Template.Application.Services;
using TP2.Template.Domain.Commands;
using TP2.Template.Domain.Entities;
using TP2.Template.Domain.Queries;

namespace TP2.Template.API
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
            services.AddControllers();            
            var connectionString = Configuration.GetSection("ConnectionString").Value;          
            services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer(connectionString));

            // Swagger
            services.AddSwaggerGen();

            // SqlKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            //Injection dependences
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<ILibroQueries, LibroQueries>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteQueries, ClienteQueries>();
            services.AddTransient<IAlquilerService, AlquilerService>();
            services.AddTransient<IAlquilerQueries, AlquilerQueries>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

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
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API V1");
                });         
        }      
    }
}
