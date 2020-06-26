using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_WSTower.Domains;
using Projeto_WSTower.Repositories;

namespace Projeto_WSTower.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private JogadorRepository _jogadorRepository = new JogadorRepository();

        /// <summary>
        /// Lista todos os jogadores 
        /// </summary>
        /// <returns>Retorna todos os jogadores/returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogadorRepository.Listar());
        }

        /// <summary>
        /// Busca o jogador pelo id informado
        /// </summary>
        /// <param name="id">Id do jogador que sera buscado</param>
        /// <returns>Retorna o objeto jogador em formato JSON</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var jogador = _jogadorRepository.BuscarPorId(id);
            if (jogador == null)
                return NotFound("Jogador não encontrado!");

            return Ok(jogador);
        }

    }
}

