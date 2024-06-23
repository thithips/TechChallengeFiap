using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.Regiao;

namespace TechChallengeFiap.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService ?? throw new ArgumentNullException(nameof(regiaoService));
        }

        /// <summary>
        /// Retorna todas as regiões cadastrada na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType<IEnumerable<RegiaoViewModel>>(200)]
        [ProducesResponseType<string>(400)]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                return Ok(await _regiaoService.BuscarTodos());
            }
            catch (Exception ex) 
            { 
            return BadRequest(ex.Message);
            }
        }
    }
}
