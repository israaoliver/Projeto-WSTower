using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_WSTower.Domains;
using Projeto_WSTower.Repositories;

namespace Projeto_WSTower.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private JogadorRepository _jogadorRepository = new JogadorRepository();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Jogador> Get()
        {
            return _jogadorRepository.Listar();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_jogadorRepository.BuscarPorId(id));
        }

    }
}

