using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_WSTower.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome de usuario obrigatório!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Apelido é obrigatório!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Apelido { get; set; }
        public byte[] Foto { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 50 caracteres")]
        public string Senha { get; set; }
    }
}
