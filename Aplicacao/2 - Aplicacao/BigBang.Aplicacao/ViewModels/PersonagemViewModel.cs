using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BigBang.Aplicacao.ViewModels
{
    public class PersonagemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [DisplayName("Data de Criação")]
        public DateTime DataCriacaoRegistro { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [DisplayName("Data de Atualização")]
        public DateTime DataAtualizacaoRegistro { get; set; }
    }
}