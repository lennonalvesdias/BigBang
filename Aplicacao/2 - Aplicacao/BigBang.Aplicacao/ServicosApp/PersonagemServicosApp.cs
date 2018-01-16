using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public PersonagemServicosApp(IPersonagemServicos servicos, IMapper mapper) {
            _servicos = servicos;
            _mapper = mapper;
        }

        void IBaseServicosApp<PersonagemViewModel>.Atualizar(PersonagemViewModel viewModel)
        {
            var personagem = _mapper.Map<Personagem>(viewModel);
            _servicos.Atualizar(personagem);
        }

        PersonagemViewModel IBaseServicosApp<PersonagemViewModel>.Buscar(Guid id)
        {
            var personagem = _servicos.Buscar(id);
            return _mapper.Map<PersonagemViewModel>(personagem);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<PersonagemViewModel>.Inserir(PersonagemViewModel viewModel)
        {
            var personagem = _mapper.Map<Personagem>(viewModel);
            _servicos.Inserir(personagem);
        }

        IList<PersonagemViewModel> IBaseServicosApp<PersonagemViewModel>.Listar()
        {
            var personagens = _servicos.Listar();
            return _mapper.Map<IList<PersonagemViewModel>>(personagens);
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