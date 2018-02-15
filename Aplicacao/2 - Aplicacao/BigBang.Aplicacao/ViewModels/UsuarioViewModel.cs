using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BigBang.Aplicacao.ViewModels
{
    public class UsuarioViewModel
    {

        [Required(ErrorMessage = "O apelido é obrigatório.")]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}