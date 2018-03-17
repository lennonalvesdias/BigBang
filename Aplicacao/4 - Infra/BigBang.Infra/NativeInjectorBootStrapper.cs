using AutoMapper;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ServicosApp;
using BigBang.Dados.Contexto;
using BigBang.Dados.Repositorios;
using BigBang.Dominio.Interfaces.Repositorios;
using BigBang.Dominio.Interfaces.Servicos;
using BigBang.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace BigBang.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Aplicacao
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IPersonagemServicosApp, PersonagemServicosApp>();
            services.AddScoped<IUsuarioServicosApp, UsuarioServicosApp>();

            // Dominio
            services.AddScoped<IPersonagemServicos, PersonagemServicos>();
            services.AddScoped<IUsuarioServicos, UsuarioServicos>();

            // Infra
            services.AddScoped<BigBangContexto>();

            services.AddScoped<IPersonagemRepositorio, PersonagemRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}