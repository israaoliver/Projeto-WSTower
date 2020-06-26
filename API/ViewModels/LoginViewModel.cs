using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "O usuário é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 50 caracteres")]
        public string Senha { get; set; }
    }
}
