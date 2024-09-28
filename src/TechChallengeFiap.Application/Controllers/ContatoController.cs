using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.Contatos;

namespace TechChallengeFiap.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
            => _contatoService = contatoService ?? throw new ArgumentNullException(nameof(contatoService));

        /// <summary>
        /// Retorna todos os contatos cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType<IEnumerable<ContatoViewModel>>(200)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _contatoService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os contatos de uma regiao
        /// </summary>
        /// <param name="idRegiao">Id da regiao a ser pesquisada</param>
        /// <returns></returns>
        [HttpGet("Regiao")]
        [ProducesResponseType<string>(400)]
        [ProducesResponseType<IEnumerable<ContatoViewModel>>(200)]
        public async Task<IActionResult> BuscarPorRegiao(Guid idRegiao)
        {
            try
            {
                return Ok(await _contatoService.BuscarPorRegiao(idRegiao));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os contatos com o ddd informado
        /// </summary>
        /// <param name="idDDD">Id do ddd a ser pesquisado</param>
        /// <returns></returns>
        [HttpGet("DDD")]
        [ProducesResponseType<IEnumerable<ContatoViewModel>>(200)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> BuscarPorDDD(Guid idDDD)
        {
            try
            {
                return Ok(await _contatoService.BuscarPorDDD(idDDD));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna os dados de um contato
        /// </summary>
        /// <param name="id">Id do contato que será visualizado</param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType<ContatoViewModel>(200)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            try
            {
                return Ok(await _contatoService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo contato na base de dados
        /// </summary>
        /// <param name="model">Dados do contato a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> Cadastrar(ContatoInputModel model)
        {
            try
            {
                await _contatoService.Cadastrar(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera as informações de um contato
        /// </summary>
        /// <param name="model">Dados do contato a ser alterado</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> Alterar(ContatoUpdateInputModel model)
        {
            try
            {
                await _contatoService.Alterar(model);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete o contato conforme o id informado
        /// </summary>
        /// <param name="id">Id do contato a ser excluido</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> Deletar(Guid id)
        {
            try
            {
                await _contatoService.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
