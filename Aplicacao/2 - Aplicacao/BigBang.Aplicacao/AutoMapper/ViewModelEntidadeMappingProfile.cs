using AutoMapper;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;

namespace BigBang.Aplicacao.AutoMapper
{
    public class ViewModelEntidadeMappingProfile : Profile
    {
        public ViewModelEntidadeMappingProfile()
        {
            CreateMap<PersonagemViewModel, Personagem>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}