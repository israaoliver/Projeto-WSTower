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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        PrincipalRepository repository = new PrincipalRepository();

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpGet("{filtro}")]
        public ActionResult ListarPorNome(string filtro)
        {
            return Ok(repository.ListarPorNome(filtro));
        }

        [HttpGet("Data/{data}")]
        public ActionResult ListarPorData(DateTime data)
        {
            return Ok(repository.ListarPorData(data));
        }
    }
}
