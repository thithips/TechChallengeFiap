using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Domain.Interfaces.Service;

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

        [HttpGet]
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
