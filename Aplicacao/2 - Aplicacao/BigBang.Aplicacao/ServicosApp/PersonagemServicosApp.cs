using System;
using System.Collections.Generic;
using System.Linq;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using RecursosCompartilhados.Aplicacao.ServicosApp;
using RecursosCompartilhados.Aplicacao.ViewModel;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;

namespace BigBang.Aplicacao.ServicosApp
{
    public class PersonagemServicosApp : IPersonagemServicosApp
    {
        private readonly IPersonagemServicos _servicos;

        public PersonagemServicosApp(IPersonagemServicos servicos) {
            _servicos = servicos;
        }

        void IBaseServicosApp<PersonagemViewModel>.Atualizar(PersonagemViewModel viewModel)
        {
            Personagem map = EntidadeGenerica<PersonagemViewModel, Personagem>.ConverterViewModelEntidade(viewModel);
            _servicos.Atualizar(map);
        }

        PersonagemViewModel IBaseServicosApp<PersonagemViewModel>.Buscar(Guid id)
        {
            var personagem = _servicos.Buscar(id);
            return EntidadeGenerica<Personagem, PersonagemViewModel>.ConverterViewModelEntidade(personagem);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<PersonagemViewModel>.Inserir(PersonagemViewModel viewModel)
        {
            Personagem map = EntidadeGenerica<PersonagemViewModel, Personagem>.ConverterViewModelEntidade(viewModel);
            _servicos.Inserir(map);
        }

        IQueryable<PersonagemViewModel> IBaseServicosApp<PersonagemViewModel>.Listar()
        {
            var personagens = _servicos.Listar();
            var map = EntidadeGenerica<Personagem, PersonagemViewModel>.ConverterListaViewModelEntidade(personagens);
            return map;
        }

        void IBaseServicosApp<PersonagemViewModel>.Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<PersonagemViewModel>.Salvar()
        {
            return _servicos.Salvar();
        }
    }
}