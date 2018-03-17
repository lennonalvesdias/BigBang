using System.Collections.Generic;
using AutoMapper;

namespace RecursosCompartilhados.Aplicacao.ViewModel
{
    public class EntidadeGenerica<TViewModel, TEntidade>
    {
        public EntidadeGenerica()
        {
            Mapper.Initialize(config => config.CreateMap<TViewModel, TEntidade>());
        }

        public static TEntidade ConverterViewModelEntidade(TViewModel vm)
        {
            Mapper.Initialize(config => config.CreateMap<TViewModel, TEntidade>());
            return Mapper.Map<TViewModel, TEntidade>(vm);
        }

        public static IList<TEntidade> ConverterListaViewModelEntidade(IList<TViewModel> vm)
        {
            return Mapper.Map<IList<TViewModel>, IList<TEntidade>>(vm);
        }
    }
}