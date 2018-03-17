using System;
using System.IO;
using AutoMapper;
using BigBang.Dados.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BigBang.Aplicacao.ViewModels;
using Microsoft.Extensions.Options;
using System.Linq;
using BigBang.Dominio.Entidades;

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
            services.AddAutoMapper();

            var login = new Login();
            services.AddSingleton(login);

            var token = new Token();
            new ConfigureFromConfigurationOptions<Token>(Configuration.GetSection("TokenConfigurations")).Configure(token);
            services.AddSingleton(token);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearer =>
            {
                var paramsValidation = bearer.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = login.Chave;
                paramsValidation.ValidAudience = token.Publico;
                paramsValidation.ValidIssuer = token.Emissor;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

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

                s.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "A autorização da API pode ser feita utilizando 'bearer ' e o token gerado pelo controller '/usuarios/login'. (Ex: bearer xXxXxXxXxXxXxXx).",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });

            services.AddMvc();

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

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var BigBangContextService = serviceScope.ServiceProvider.GetRequiredService<BigBangContexto>();
                BigBangContextService.Database.Migrate();
                if (!BigBangContextService.Usuarios.Any())
                {
                    var admin = new Usuario("administrador", "admin", "admin");
                    BigBangContextService.Usuarios.Add(admin);
                    BigBangContextService.SaveChanges();
                }
                if (!BigBangContextService.Personagens.Any())
                {
                    var sheldon = new Personagem("Sheldon Cooper");
                    var leonard = new Personagem("Leonard Hofstadter");
                    var penny = new Personagem("Penny");
                    BigBangContextService.Personagens.Add(sheldon);
                    BigBangContextService.Personagens.Add(leonard);
                    BigBangContextService.Personagens.Add(penny);
                    BigBangContextService.SaveChanges();
                }
            }
        }

        private static void RegisterServices(IServiceCollection services)
        {
            Infra.NativeInjectorBootStrapper.RegisterServices(services);
            RecursosCompartilhados.Infra.NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
