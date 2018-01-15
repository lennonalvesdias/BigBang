using System;
using System.IO;
using System.Net.Http;
using AutoMapper;
using BigBang.Dados.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BigBang.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddAutoMapper();
            
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("V1", new Info
                {
                    Title = "BigBang .NET Core",
                    Version = "v1",
                    Description = "Projeto em .NET Core 2 utilizando DDD.",
                    TermsOfService = "...",
                    Contact = new Contact { Name = "Lennon V. Alves Dias", Email = "lennonalvesdias@gmail.com", Url = "http://www.lennonalves.com.br" },
                    License = new License { Name = "", Url = "" }
                });
            });

            services.AddMvc();

            // services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Swagger/V1/swagger.json", "BigBang v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            BigBang.Infra.NativeInjectorBootStrapper.RegisterServices(services);
            RecursosCompartilhados.Infra.NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
