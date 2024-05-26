using Microsoft.AspNetCore.Mvc;
using TechChallengeFiap.Domain.Interfaces.Service;

namespace TechChallengeFiap.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : ControllerBase
    {
        private readonly IDDDService _dDDService;

        public DDDController(IDDDService dddService)
        {
            _dDDService = dddService;
        }

        [HttpGet]
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
