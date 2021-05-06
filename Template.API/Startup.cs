using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Template.AccessData;
using Template.AccessData.Commands;
using Template.AccessData.Queries;
using Template.Application.Services;
using Template.Domain.Commands;
using Template.Domain.Mapper;
using Template.Domain.Queries;

namespace Template.API
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

            var mapperConfig = new MapperConfiguration(mc =>
           {
               mc.AddProfile(new UsuarioProfile());
           });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            // Configuration busca diferentes opciones en appsettings.json; en este caso, le pedimos
            // el valor de la clave ConnectionString
            string connectionString = Configuration.GetSection("ConnectionString").Value;

            // Una vez que tenemos el string para conectarnos a la BD, se lo pasamos el m�todo UseSqlServer()
            services.AddDbContext<UsuarioDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Usuario API",
                        Version = "v1"
                    });
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Usuario API");
            }); 

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
