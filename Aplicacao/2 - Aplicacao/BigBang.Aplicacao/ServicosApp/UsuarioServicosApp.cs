using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;
using BigBang.Dominio.Interfaces.Servicos;
using Microsoft.IdentityModel.Tokens;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;

namespace BigBang.Aplicacao.ServicosApp
{
    public class UsuarioServicosApp : IUsuarioServicosApp
    {
        private readonly IUsuarioServicos _servicos;
        private readonly IMapper _mapper;

        public UsuarioServicosApp(IUsuarioServicos servicos, IMapper mapper)
        {
            _servicos = servicos;
            _mapper = mapper;
        }

        object IUsuarioServicosApp.Login(UsuarioViewModel viewModel, Login login, Token token)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            var entrar = _servicos.Login(usuario);

            bool usuarioValido = entrar != null;

            if (usuarioValido)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(entrar.Apelido, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, entrar.Apelido)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(token.Segundos);

                var handler = new JwtSecurityTokenHandler();
                var secutityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = token.Emissor,
                    Audience = token.Publico,
                    SigningCredentials = login.Credenciais,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

                var accesstoken = handler.WriteToken(secutityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = accesstoken,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        void IBaseServicosApp<UsuarioViewModel>.Atualizar(UsuarioViewModel viewModel)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Atualizar(usuario);
        }

        UsuarioViewModel IBaseServicosApp<UsuarioViewModel>.Buscar(Guid id)
        {
            var usuario = _servicos.Buscar(id);
            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<UsuarioViewModel>.Inserir(UsuarioViewModel viewModel)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Inserir(usuario);
        }

        IList<UsuarioViewModel> IBaseServicosApp<UsuarioViewModel>.Listar()
        {
            var usuarios = _servicos.Listar();
            return _mapper.Map<IList<UsuarioViewModel>>(usuarios);
        }

        void IBaseServicosApp<UsuarioViewModel>.Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<UsuarioViewModel>.Salvar()
        {
            return _servicos.Salvar();
        }
    }
}