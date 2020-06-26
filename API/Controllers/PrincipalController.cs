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
    [ApiController]
    [Authorize]
    public class PrincipalController : ControllerBase
    {
        PrincipalRepository repository = new PrincipalRepository();

        /// <summary>
        /// Lista todos os confrontos em ordem decrecente
        /// </summary>
        /// <returns>Retorna uma lista JSON com os confrontos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(repository.Listar());
        }


        /// <summary>
        /// Pelo filtro informado faz uma busca geral
        /// </summary>
        /// <param name="filtro">Paramentro utilizado para fazer uma busca de acordo com o digitado</param>
        /// <returns>Retorna uma Lista com todas os objetos encontrados</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{filtro}")]
        public ActionResult ListarPorNome(string filtro)
        {
            return Ok(repository.ListarPorNome(filtro));
        }


        /// <summary>
        /// Filtra os confrontos apenas da data informada
        /// </summary>
        /// <param name="data">Data informada para encontrar os confrontos</param>
        /// <returns>Retorna uma lista com todos os confrontos da data informada</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Data/{data}")]
        public ActionResult ListarPorData(DateTime data)
        {
            return Ok(repository.ListarPorData(data));
        }
    }
}
