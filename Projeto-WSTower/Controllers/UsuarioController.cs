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

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [HttpPost]
        public ActionResult Cadastrar(Usuario user)
        {
            if ((_usuarioRepository.BuscarPorEmail(user.Email) != null))
                return StatusCode(303, "Email existente ");
            if (_usuarioRepository.BuscarPorApelido(user.Apelido) != null)
                return StatusCode(303, "Apelido existente ");

            _usuarioRepository.Cadastrar(user);
            return StatusCode(201, "Usuario criado");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Atualizar(int id,Usuario userAtualizado)
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
