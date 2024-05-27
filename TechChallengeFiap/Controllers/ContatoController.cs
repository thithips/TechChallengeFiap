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
        {
            _contatoService = contatoService ?? throw new ArgumentNullException(nameof(contatoService));
        }

        [HttpGet]
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

        [HttpGet("Regiao")]
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

        [HttpGet("DDD")]
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

        [HttpGet("{id:Guid}")]
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

        [HttpPost]
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

        [HttpPut]
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

        [HttpDelete]
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
