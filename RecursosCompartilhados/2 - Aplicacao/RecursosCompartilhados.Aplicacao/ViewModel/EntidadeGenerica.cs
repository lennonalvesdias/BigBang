using System.Linq;
using AutoMapper;

namespace RecursosCompartilhados.Aplicacao.ViewModel
{
    public class EntidadeGenerica<TViewModel, TEntidade>
    {

        // public EntidadeGenerica()
        // {
        //     Mapper.Initialize(config => config.CreateMap<TViewModel, TEntidade>());
        // }

        public static TEntidade ConverterViewModelEntidade(TViewModel vm)
        {
            Mapper.Initialize(config => config.CreateMap<TViewModel, TEntidade>());
            return Mapper.Map<TViewModel, TEntidade>(vm);
        }

        public static IQueryable<TEntidade> ConverterListaViewModelEntidade(IQueryable<TViewModel> vm)
        {
            return Mapper.Map<IQueryable<TViewModel>, IQueryable<TEntidade>>(vm);
        }
    }
}