using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;

namespace RecursosCompartilhados.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Dominio
            services.AddScoped<INotificationHandler<NotificacaoDeDominio>, GerenciadorDeNotificacoes>();
        }
    }
}