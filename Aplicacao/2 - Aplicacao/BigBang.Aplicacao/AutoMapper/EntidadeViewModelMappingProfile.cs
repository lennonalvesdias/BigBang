using AutoMapper;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;

namespace BigBang.Aplicacao.AutoMapper
{
    public class EntidadeViewModelMappingProfile : Profile
    {
        public EntidadeViewModelMappingProfile() 
        {
            CreateMap<Personagem, PersonagemViewModel>();
        }
    }
}