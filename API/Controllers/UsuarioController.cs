using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_WSTower.Domains;
using Projeto_WSTower.Repositories;
using Projeto_WSTower.ViewModels;

namespace Projeto_WSTower.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        UsuarioRepository _usuarioRepository = new UsuarioRepository();

        /// <summary>
        /// Busca o usuario pelo id informado
        /// </summary>
        /// <param name="id">Id do usuario que sera buscado</param>
        /// <returns>Retorna o objeto Usuario em formato JSON</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult BuscarPorId(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
                return NotFound("Usuario não encontrado");

            return Ok(usuario);
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Nome": "Name",
        ///        "Email" : "string",
        ///        "Apelido" : "string",
        ///        "Foto": "IMAGE",
        ///        "Senha" : "string"
        ///        }
        ///     
        ///</remarks>
        /// <param name="user">Objeto que será cadastrado</param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [HttpPost]
        public ActionResult Cadastrar(Usuario user)
        {
            try
            {
                if ((_usuarioRepository.BuscarPorEmail(user.Email) != null))
                    return StatusCode(303, "Email existente ");
                if (_usuarioRepository.BuscarPorApelido(user.Apelido) != null)
                    return StatusCode(303, "Apelido existente ");

                _usuarioRepository.Cadastrar(user);
                return StatusCode(201, "Usuario criado");

            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }

            
        }

        /// <summary>
        /// Atualiza o usuario pode ser atualizado apenas uma das informaçoes não contem senha
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Nome": "Name",
        ///        "Email" : "string",
        ///        "Apelido" : "string",
        ///        "Foto": "IMAGE",
        ///        }
        ///     
        ///</remarks>
        /// <param name="userAtualizado">Objeto que contem as informaçoes que serão alteradas</param>
        /// <param name="id">Id do Usuario que sera atualizado</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, AtlzUserViewModel userAtualizado )
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado");
            }
            if ((_usuarioRepository.BuscarPorEmail(userAtualizado.Email) != null))
                return StatusCode(303, "Email existente ");
            if (_usuarioRepository.BuscarPorApelido(userAtualizado.Apelido) != null)
                return StatusCode(303, "Apelido existente ");


            _usuarioRepository.Atualizar(id,userAtualizado);

            return Ok();
        }

        /// <summary>
        /// Atualiza apenas a senha utilizando o id para encontrar o usuario
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Id" : 0,
        ///        "Senha" : "string"
        ///        }
        ///     
        ///</remarks>
        /// <param name="AtlzSenha">Objeto que contem a senha alterada</param>
        [HttpPut("Senha")]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public ActionResult AtualizarSenha(SenhaViewModel AtlzSenha)
        {
            var user = _usuarioRepository.BuscarPorId(AtlzSenha.Id);

            if (user == null)
                return NotFound("Usuario não encontrado!");

            if (user.Senha == AtlzSenha.Senha)
                return StatusCode(304, "Nada alterado senhas igual a anterior");

            _usuarioRepository.AtulizarSenha(AtlzSenha);
            return StatusCode(202, "Senha Alterada!");

        }
    }
}
