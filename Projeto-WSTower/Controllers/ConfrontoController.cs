using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_WSTower.Repositories;

namespace Projeto_WSTower.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConfrontoController : ControllerBase
    {
        ConfrontoRepository repository = new ConfrontoRepository();

        /// <summary>
        /// GET para buscar por id o confronto
        /// </summary>
        /// <param name="id">Id do confronto que será buscado</param>
        /// <returns>Retorna o confronto</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult Confronto(int id)
        {
            return Ok(repository.Confronto(id));
        }
    }
}
