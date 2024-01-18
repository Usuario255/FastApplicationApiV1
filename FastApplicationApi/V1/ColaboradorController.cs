using FastApplication.Application.Repositories;
using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FastApplicationApi.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateColaborador([FromBody] Colaborador model)
        {           
            var colaborador = await _colaboradorService.CreateColaboradorAsync(model);
            return CreatedAtAction(nameof(GetColaborador), new { id = colaborador.Id }, colaborador);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColaborador(int id)
        {
            // Implemente a lógica para obter informações sobre um Colaborador
            var colaborador = await _colaboradorService.GetColaboradorAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }
    }
}
