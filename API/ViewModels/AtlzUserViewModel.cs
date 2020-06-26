using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.ViewModels
{
    public class AtlzUserViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Apelido { get; set; }
        public byte[] Foto { get; set; }


    }
}
