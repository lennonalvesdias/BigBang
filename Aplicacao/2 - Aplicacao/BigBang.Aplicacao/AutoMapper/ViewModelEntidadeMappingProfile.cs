using AutoMapper;
using BigBang.Aplicacao.ViewModels;
using BigBang.Dominio.Entidades;

namespace BigBang.Aplicacao.AutoMapper
{
    public class ViewModelEntidadeMappingProfile : Profile
    {
        public ViewModelEntidadeMappingProfile()
        {
            CreateMap<PersonagemViewModel, Personagem>()
                .ConstructUsing(c => new Personagem(c.Nome, c.Idade))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}