using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.Estados;

namespace TechChallengeFiap.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : ControllerBase
    {
        private readonly IDDDService _dDDService;

        public DDDController(IDDDService dddService)
            => _dDDService = dddService ?? throw new ArgumentNullException(nameof(dddService));

    /// <summary>
    /// Retorna todos os DDDs cadastrados na base de dados
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType<IEnumerable<EstadoDDDViewModel>>(200)]
    [ProducesResponseType<string>(400)]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            return Ok(await _dDDService.BuscarTodos());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
}
