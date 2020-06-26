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
    public class SelecaoController : ControllerBase
    {
        SelecaoRepository SelecaoRepository = new SelecaoRepository();


        /// <summary>
        /// Lista todas as Seleções e seus jogadores
        /// </summary>
        /// <returns>Uma Lista em JSON com todas as seleções e seus jogadores</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            // return Ok(new { mensagem = "ok" });
            return Ok(SelecaoRepository.Listar());
        }


        /// <summary>
        /// Pelo id informado busca a seleção e todos os seus jogadores
        /// </summary>
        /// <param name="id">Id da Seleção buscada</param>
        /// <returns>Retorna a Seleção encontrada com todos os seus jogadores em JSON</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {

            Selecao selecao = SelecaoRepository.BuscarPorId(id);
            if (selecao == null)
            {
                return NotFound();
            }
            return Ok(selecao);
        }

        /// <summary>
        /// Cadastra uma nova seleção
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "Nome": "Name",
        ///        "Bandeira" : "IMAGE",
        ///        "Uniforme" : "IMAGE",
        ///        "Escalacao": "string"
        ///        }
        ///     
        ///</remarks>
        /// <param name="selecao">Objeto que sera cadastrado</param>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Cadastrar(Selecao selecao)
        {
            try
            {
                SelecaoRepository.Cadastrar(selecao);
                return StatusCode(201, "Seleção cadastrada.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Pelo id informado deleta a seleção
        /// </summary>
        /// <param name="id">Id da Seleção buscada</param>
        /// <returns>Retorna uma mensagem confirmando o delete</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            
            SelecaoRepository.Deletar(id);
            return Ok();
        }


        /// <summary>
        /// Atualiza a seleção
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///      {
        ///        "id" : 0,
        ///        "Nome": "Name",
        ///        "Bandeira" : "IMAGE",
        ///        "Uniforme" : "IMAGE",
        ///        "Escalacao": "string"
        ///        }
        ///     
        ///</remarks>
        /// <param name="selecao">Objeto que sera atualizado</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public IActionResult Atualizar(Selecao selecao)
        {
            try
            {
                Selecao selecaoBuscada = SelecaoRepository.BuscarPorId(selecao.Id);
                if (selecaoBuscada == null)
                    return NotFound();
                SelecaoRepository.Atualizar(selecao);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
