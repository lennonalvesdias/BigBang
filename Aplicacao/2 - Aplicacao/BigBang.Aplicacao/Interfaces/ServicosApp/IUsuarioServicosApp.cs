using BigBang.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;

namespace BigBang.Aplicacao.Interfaces.ServicosApp
{
    public interface IUsuarioServicosApp : IBaseServicosApp<UsuarioViewModel>
    {
         object Login(UsuarioViewModel viewModel, Login login, Token token);
    }
}